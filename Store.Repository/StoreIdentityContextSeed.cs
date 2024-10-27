using Microsoft.AspNet.Identity;
using Store.Data.Entity.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Salma Nagy",
                    Email = "salmafareed998@gmail.com",
                    UserName = "salma",
                    Address = new Address
                    {
                        FirstName = "Salma",
                        LastName = "Farid",
                        City = "Cairo",
                        State = "Cairo",
                        Street = "1",
                        PostalCode = "12345",
                    }
                };
                await userManager.CreateAsync(user,"P@ssw0rd");
            }
        }
    }
}
