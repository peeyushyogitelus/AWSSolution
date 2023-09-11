using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSMavenPages.Models;
using static PSMavenPages.Models.MavenObject;

namespace AWS_app.Controllers {
    public class AWSController : Controller {
        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString(SessionField.Mlbearer) == null) // Get the token details if not available in the current session
                {
                    PageInfo _pageInfo = new ()
                    {
                        ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString(),
                        MethodName = this.ControllerContext.RouteData.Values["action"].ToString()
                    };
                    TempData["PageInfo"] = JsonConvert.SerializeObject(_pageInfo);
                    //Redirected to Authenticate page to get the user token details
                    return RedirectToAction("Index", "Authenticate");
                }
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);
            }
            return View();
        }

    }
}
