using ContactDBandProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactDBandProduct.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
