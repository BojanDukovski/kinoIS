using Microsoft.AspNetCore.Identity;

namespace KinoISAdminApplication.Models
{
    public class KinoUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public ShoppingCart UserCart { get; set; }
        public string UserName
        {
            get;
            set;
        }
        public string NormalizedUserName
        {
            get;
            set;
        }
        [ProtectedPersonalData]
        public string Email
        {
            get;
            set;
        }
        public string NormalizedEmail
        {
            get;
            set;
        }

    }
}
