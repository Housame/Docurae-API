using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Models.Entities
{
    public partial class IdDbContext : IdentityDbContext<ApplicationUser>
    // AppDbContext
    {
        public IdDbContext(DbContextOptions<IdDbContext> options) : base(options)
        {
        }
    }

    public class ApplicationUser : IdentityUser
    {
    }
    public class ApplicationRole : IdentityRole
    {

    }
    public partial class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
