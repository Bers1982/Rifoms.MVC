using Microsoft.AspNetCore.Identity;
using Rifoms.Domain.Context;
using Rifoms.Domain.Data.Entities.App;
using Rifoms.Domain.Data.Entities.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rifoms.Web.Infrastructure.DbInitializer
{
    public class RoleInitializer
    {
        #region private string properties
        private static readonly string admin1Email = "Vartatil@gmail.com";
        private static readonly string admin1Password = "Qwerty";
        private static readonly string admin1Surname = "Торшхоев";
        private static readonly string admin1Name = "Исмаил";
        private static readonly string admin1FatherName = "Магомедович";
        private static readonly string admin1Mobile = "+79299408520";

        private static readonly string admin2Email = "bersagiev@gmail.com";
        private static readonly string admin2Password = "Sovarizm82!";
        private static readonly string admin2Surname = "Агиев";
        private static readonly string admin2Name = "Дауд";
        private static readonly string admin2FatherName = "Русланович";
        private static readonly string admin2Mobile = "+79381125720";
        #endregion
        public static async Task InitializeAsync(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            RifomsDbContext dbContext)
        {
            await CreateRole(roleManager, "admin");
            await CreateRole(roleManager, "manager");
            await CreateRole(roleManager, "client");

            await CreatUserAddToRole(userManager, dbContext,
                        new Dictionary<string, string>
                        {
                            { "Email",admin1Email },
                            { "Password",admin1Password },
                            { "Role","admin" },
                            { "Surname",admin1Surname },
                            { "Name",admin1Name },
                            { "FatherName",admin1FatherName},
                            { "Mobile",admin1Mobile }
                        });

            await CreatUserAddToRole(userManager, dbContext,
                        new Dictionary<string, string>
                        {
                            { "Email",admin2Email },
                            { "Password",admin2Password },
                            { "Role","admin" },
                            { "Surname",admin2Surname },
                            { "Name",admin2Name },
                            { "FatherName",admin2FatherName},
                            { "Mobile",admin2Mobile }
                        });
        }

        /// <summary>
        /// Метод для создания первичнных пользователей для авторизации в БД  
        /// </summary>
        /// <param name="userManager">userManager</param>
        /// <param name="parameters">Словарик параметров, в нем  передаются userEmail,userPassword и роль, 
        /// которавя будет присвоена пользхователю</param>
        /// <returns></returns>
        private static async Task CreatUserAddToRole(
            UserManager<AppUser> userManager,
            RifomsDbContext dbContext,
            Dictionary<string, string> parameters)
        {
            if (await userManager.FindByNameAsync(parameters["Email"]) == null)
            {
                AppUser appUser = new AppUser
                {
                    Email = parameters["Email"],
                    UserName = parameters["Email"],
                    Password = parameters["Password"],
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(appUser, parameters["Password"]);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, parameters["Role"]);

                    var user = new CmsUser
                    {
                        AppUserId = appUser.Id,
                        Surname = parameters["Surname"],
                        Name = parameters["Name"],
                        Fathername = parameters["FatherName"],
                        Mobile = parameters["Mobile"],
                        Email = parameters["Email"],
                        //RowStatusId = dbContext.RowStatuses.SingleOrDefault(c => c.Name == RowStatusEnum.Created.GetString()).Id
                    };
                    await dbContext.CmsUsers.AddAsync(user);
                    await dbContext.SaveChangesAsync();

                    //accessrights for admin users то есть для ШАМИЛЯ и МЕНЯ
                    //await dbContext.AccessRight.AddAsync(new AccessRight
                    //{
                    //    UserId = user.Id,
                    //    AllClients = true,
                    //    EnableClient = true,
                    //    EnableReport = true,
                    //    EnableSverka = true,
                    //    EnableZayavka = true,
                    //    EnableCheckEndDate = true,
                    //    EnableReplaceZayavka = true,
                    //    EnablePrice = true,
                    //    AvailableStatusZayavki = "All"
                    //});
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private static async Task CreateRole(RoleManager<AppRole> roleManager, string roleName)
        {
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName });
            }
        }
    }
}
