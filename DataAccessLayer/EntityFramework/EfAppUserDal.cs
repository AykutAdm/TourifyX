using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public void UpdateAppUser(AppUser appUser)
        {
            using (var context = new Context())
            {
                var existingUser = context.Users.Find(appUser.Id);
                if (existingUser != null)
                {
                    existingUser.Name = appUser.Name;
                    existingUser.Surname = appUser.Surname;
                    existingUser.UserName = appUser.UserName;
                    existingUser.Email = appUser.Email;
                    existingUser.PhoneNumber = appUser.PhoneNumber;
                    existingUser.ImageUrl = appUser.ImageUrl;
                    existingUser.Gender = appUser.Gender;
                    context.SaveChanges();
                }
            }
        }
    }
}
