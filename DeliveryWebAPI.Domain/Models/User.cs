using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryWebAPI.Domain.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string ImgURL { get; set; }

        public Branch Branch { get; set; }

        public decimal Sallary { get; set; }

        public bool IsBlocked { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }

    public class Personal : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string ImgURL { get; set; }

        public Branch Branch { get; set; }

        public bool IsBlocked { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }
}
