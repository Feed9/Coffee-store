using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Coffee_store.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            { }
            if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();

                var checkAdmin = _context.Users.FirstOrDefault(u => u.UserName == "test@yandex.ru");

                if (checkAdmin == null)
                {
                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "test@yandex.ru",
                        Email = "test@yandex.ru",
                        EmailConfirmed = true,
                        FirstName = "Fedor",
                        LastName = "Suslov"
                    }, "Admin1*").GetAwaiter().GetResult();

                    var admin = _context.Users.FirstOrDefault(u => u.UserName == "test@yandex.ru");
                    _userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
                }                
            }
            return;
        }
    }
}
