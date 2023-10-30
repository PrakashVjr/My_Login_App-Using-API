using MyApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public interface IEmployeelistRepository
    {
        Task<UserInfo> UserInfo
            (string FirstName ,
                string LastName,
                string Email,
                string PhoneNumber,
                string Address,
                string ZipCode,
                string Dob,
                string Gender,
                string Age,
                string MarriedStatus,
                string Files
            );
    }
}
