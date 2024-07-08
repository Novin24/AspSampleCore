using IdetntityUserServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdetntityUserServer.Data
{
    public class UserIdentityDbContext : IdentityDbContext<IdeUser, IdentityRole<Guid>, Guid>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
        {
        }
    }
}
