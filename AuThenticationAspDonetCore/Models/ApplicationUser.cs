using System;
using Microsoft.AspNetCore.Identity;

namespace AuThenticationAspDonetCore.Models
{
    public class ApplicationUser: IdentityUser
    {
        public String FullName { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public string CredentialId{ get; set; }
        public string HealthCareId { get; set; }
    }
}