using Microsoft.EntityFrameworkCore;
using VerificationProvider.Models;

namespace VerificationProvider.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<VerificationRequest> VerificationRequests { get; set; }
}
