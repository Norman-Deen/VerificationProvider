﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VerificationProvider.Data.Contexts;
using VerificationProvider.Models;

namespace VerificationProvider.Services
{
    public class ValidateVerificationCodeService : IValidateVerificationCodeService
    {
        private readonly ILogger<ValidateVerificationCodeService> _logger;
        private readonly DataContext _context;

        public ValidateVerificationCodeService(ILogger<ValidateVerificationCodeService> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ValidateRequest> UnpackValidateRequestAsync(HttpRequest req)
        {
            try
            {
                var body = await new StreamReader(req.Body).ReadToEndAsync();

                if (!string.IsNullOrEmpty(body))
                {
                    var validateRequest = JsonConvert.DeserializeObject<ValidateRequest>(body);
                    if (validateRequest != null)
                        return validateRequest;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: ValidateVerificationCodeService.UnpackValidateRequestAsync() :: {ex.Message}");
            }

            return null;
        }

        public async Task<bool> ValidateCodeAsync(ValidateRequest validateRequest)
        {
            try
            {
                var entity = await _context.VerificationRequests.FirstOrDefaultAsync(x => x.Email == validateRequest.Email && x.Code == validateRequest.Code);
                if (entity != null)
                {
                    _context.VerificationRequests.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: ValidateVerificationCodeService.ValidateCodeAsync() :: {ex.Message}");
            }

            return false;
        }
    }
}
