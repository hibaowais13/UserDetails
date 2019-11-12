using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserDetails.Models
{
    public class User

    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Role> Roles { get; set; }


    }
}