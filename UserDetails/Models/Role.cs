using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace UserDetails.Models
{
    public class Role
    {
        public Role()
        {
          
            //UserRoles = new HashSet<UserRole>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string RoleName { get; set; }

        public  ICollection<UserRole> UserRoles { get; set; }
    }
}