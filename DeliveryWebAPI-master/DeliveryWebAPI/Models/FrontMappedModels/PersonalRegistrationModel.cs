using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Models.FrontMappedModels
{
    public class PersonalRegistrationModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int BranchId { get; set; }

        public string RoleId { get; set; }

        public string ImgURL { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}
