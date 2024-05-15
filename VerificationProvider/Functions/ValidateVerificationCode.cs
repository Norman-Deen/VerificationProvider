using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VerificationProvider.Data.Contexts;
using VerificationProvider.Models;

namespace VerificationProvider.Functions
{
    public class ValidateVerificationCode
    {
        private readonly ILogger<ValidateVerificationCode> _logger;
        private readonly DataContext _context;

        public ValidateVerificationCode(ILogger<ValidateVerificationCode> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("ValidateVerificationCode")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "validate")] HttpRequest req)
        {
            try
            {
                var validateRequest = await UnpackValidateRequestAsync(req);
                if (validateRequest != null)
                {
                    var validateResult = await ValidateCodeAsync(validateRequest);
                    if (validateResult)
                    {
                        return new OkResult();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: ValidateVerificationCode.Run() :: {ex.Message}");
            }

            return new UnauthorizedResult();
        }

        private async Task<ValidateRequest> UnpackValidateRequestAsync(HttpRequest req)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();
                if (!string.IsNullOrEmpty(body))
                {
                    return JsonConvert.DeserializeObject<ValidateRequest>(body);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: ValidateVerificationCode.UnpackValidateRequestAsync() :: {ex.Message}");
            }
            return null;
        }

        private async Task<bool> ValidateCodeAsync(ValidateRequest validateRequest)
        {
            try
            {
                var entity = await _context.VerificationRequests.FirstOrDefaultAsync(x => x.Email == validateRequest.Email && x.Code == validateRequest.Code);
                return entity != null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: ValidateVerificationCode.ValidateCodeAsync() :: {ex.Message}");
            }
            return false;
        }
    }
}
