using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AutomobileClassification.Core.Infrastructure.Identity
{
   public class ApplicationUser : IdentityUser<long>
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; } = null;
        [MaxLength(50)]
        public string LastName { get; set; }

    }
}