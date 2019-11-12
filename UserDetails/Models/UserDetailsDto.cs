using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDetails.Models
{
    public class UserDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RoleDetails> Roles { get; set; }


    }
    public class RoleDetails
    {
   
        public long RoleId { get; set; }
        public string RoleName { get; set; }
       
    }
}