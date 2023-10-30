using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class UserInfo
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Dob { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

        public string MarriedStatus { get; set; }

        public string Files { get; set; }

    }
}
