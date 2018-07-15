using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProjetoFinal2.Models;

[assembly: OwinStartupAttribute(typeof(ProjetoFinal2.Startup))]
namespace ProjetoFinal2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            inic();
        }
        private void inic()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Admin'
            if (!roleManager.RoleExists("Admin"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }



            // criar um utilizador 'Admin'
            var user = new ApplicationUser();
            user.UserName = "RobertStrickland";
            user.Email = "robertms@hotmail.com";
            string userPWD = "123_Asd";
            var chkUser = userManager.Create(user, userPWD);


            // criar um utilizador 'utilizador1'
            var user2 = new ApplicationUser();
            user2.UserName = "LiletteThorne";
            user2.Email = "l.thorne@gmail.com";
            string userPWD2 = "123_Asd";
            var chkUser2 = userManager.Create(user2, userPWD2);

            //Adicionar o Utilizador à respetiva Role-Admin
            if (chkUser.Succeeded) { }
            var result1 = userManager.AddToRole(user.Id, "Admin");
        }
        }

    }
}

