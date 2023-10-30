using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EamonnCoyleATM.Models.ATM.Login
{
    public class LoginModel : PageModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool LoginFailed { get; set; }

        
    }
}
