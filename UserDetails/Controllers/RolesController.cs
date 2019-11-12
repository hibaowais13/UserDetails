using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDetails.Models;
using UserDetails.Context;
using System.Data.Entity;

namespace UserDetails.Controllers

{

    public class RolesController : ApiController
    {
  

       
        
        public List<User> Get()
        {
            using (UserDbContext db = new UserDbContext())
            {
           return   db.Users.Include(y=>y.UserRoles.Select(k=>k.Role)).ToList();
                
               
                //return db.Users.Include(UserRole).Select(p => new UserDetailsDto
                //{
                //    FirstName = p.FirstName,
                //    LastName = p.LastName,
                //    Email = p.Email,
                //    UserName = p.UserName,
                //    Phone = p.Phone,
                //    UserRoles = p.UserRoles.ToList()





                //}).ToList();
            }

        }


        public List<User> Get(int id)
        {
            
            using (UserDbContext db = new UserDbContext())
            {

             return  db.Users.Where(x => x.Id == id).Include(y => y.UserRoles.Select(k => k.Role)).ToList();
             
                    //.Select(x => new UserDetailsDto
                    //{
                    //    FirstName = x.FirstName,
                    //    LastName = x.LastName,
                    //    Email = x.Email,
                    //    UserName = x.UserName,
                    //    Phone = x.Phone,
                    //    UserRoles = x.UserRoles.ToList(),
                    //    Roles = x.Roles.Select(k => new RoleDetails { RoleId = k.Id, RoleName = k.RoleName }).ToList()




                    //}).ToList();
            }

        }
     


        public IHttpActionResult Post(User user)
        {
            using (UserDbContext db = new UserDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Users.Add(user);
                db.SaveChanges();
                

                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
          

        }

        public IHttpActionResult Put(UserRole userrole, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (UserDbContext db = new UserDbContext())
            {
                //var existinguser = db.Users.Where(s => s.Id == id).FirstOrDefault<User>();


                var existingrole = db.UserRoles.Where(a => a.UserId == id).FirstOrDefault<UserRole>();
                if (existingrole != null)
                {
                    //existinguser.FirstName = user.FirstName;
                    //existinguser.LastName = user.LastName;
                    existingrole.RoleId = userrole.RoleId;
                    Console.WriteLine("Role for this existing user updated sucessfully");
                    db.SaveChanges();
                    
                 
                }
                
               
                   
                 else
                {

                    db.UserRoles.Add(new UserRole()
                    {
                        UserId = id,
                        RoleId = userrole.RoleId,
                       


                    });
                    db.SaveChanges();
                    Console.WriteLine("Role for this non existing user added successfully");
                }
            }
            return Ok(/*"UserRole updated successfully"*/);
        }
    }

}









//public IQueryable<Object> GetArtists()
//{
//    return db.Artists
//            .Include(a => a.Projects)
//            .Select(a =>
//                new
//                {
//                    name = a.ArtistName,
//                    projects = a.Projects.Select(p => p.ProjectName)
//                });
//}







//var user = (from u in db.Users
//            join e in db.UserRoles
//            on u.Id equals e.UserId
//            where u.Id == id
//            select new
//            {
//                FirstName = u.FirstName,
//                LastName = u.LastName,
//                Email = u.Email,
//                UserName = u.UserName,
//                Phone = u.Phone,
//                RoleId = e.RoleId
//            }).ToList();


//from a in db.Users
//                   join p in db.UserRoles on a.Id equals p.UserId into userUserRoles
//                   select new
//                       {
//                           FirstName = a.FirstName,
//                           LastName = a.LastName,
//                           Email = a.Email,
//                           UserName = a.UserName,
//                           Phone = a.Phone,
//                           Roles = userUserRoles.Select(ap => ap.UserId)


//[HttpGet]
//public IEnumerable<UserRole> GetStudents()
//{
//    using (UserDbContext db = new UserDbContext())
//        return db.UserRoles.Include(c => c.Users);
//}