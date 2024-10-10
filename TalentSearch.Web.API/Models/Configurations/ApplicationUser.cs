using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TalentSearch.Web.API.Models.Configurations
{
    //
    public class ApplicationUser : IdentityUser
    {
        public bool Active { get; set; }

        public Guid ModulePersonId { get; set; }

        //public string ThumbnailPicture { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string? ModifiedBy { get; set; }

        public Guid? Token { get; set; }

        public string? JWTToken { get; set; }
    }
}
