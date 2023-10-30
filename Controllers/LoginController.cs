using EamonnCoyleATM.Models.ATM.Login;
using EamonnCoyleATM.Services.ATMActions;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    ILoginService _loginService;
    //ctor
    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    // GET: Login
    public ActionResult Index()
    {
        LoginModel loginModel = new LoginModel();

        return View("LoginView", loginModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(string username, string password)
    {
        var clientId = _loginService.WithUsername(username).WithPassword(password).LoginAsync().Result;
        if(clientId == 0)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.LoginFailed = true;
            return View("LoginView", loginModel);
        }
        else
        {

            return RedirectToAction("Index", "ClientSummary", new { clientId = clientId });
        }   

    }
}
