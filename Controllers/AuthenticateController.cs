using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PSMavenPages.Auth;
using PSMavenPages.Models;
using System.Xml;

namespace PSMavenPages.Controllers
{
    //[EnableCors("MyPolicy")]
    public class AuthenticateController : Controller
    {
        public IConfiguration Configuration { get; }
        public AuthenticateController(IConfiguration iConfig)
        {
            Configuration = iConfig;
        }
        public IActionResult Index()
        {
            string strAppId = "d9f806f44b1a3502b05bb5ed489f0d28230e11165e97825a9a6067cd852af334";
            string strAppSecret = "99ed0940ce34dc5758b09f020c9db576998948b1973670c932fdbe1334b39b70";
            
            string strUrl = "http://awsapp-test.us-east-1.elasticbeanstalk.com/Authenticate";
            //strUrl = "https://localhost:7153/Authenticate";
            if (!string.IsNullOrEmpty(HttpContext.Request.Query["code"].ToString()))
            {
                string theUrl = string.Format(MavenObject.APITokenGeneration.ToString(),
                                               strAppId,
                                               strAppSecret,
                                               strUrl,
                                               HttpContext.Request.Query["code"].ToString());
                AuthMethods authMethods = new AuthMethods();
                string rawToken = authMethods.PostJsonWithToken(theUrl);
                rawToken = @"{'root':" + rawToken + "}";

                // no error handling for rawToken
                XmlDocument doc = JsonConvert.DeserializeXmlNode(rawToken);
                _ = new LogInUserDetails()
                {
                    AccessToken = doc.SelectSingleNode("//access_token").InnerText
                };
                HttpContext.Session.SetString("AccessToken", doc.SelectSingleNode("//access_token").InnerText);
                SetUserInformation(doc.SelectSingleNode("//access_token").InnerText);
                PageInfo _pageInfo = JsonConvert.DeserializeObject<PageInfo>((string)TempData["PageInfo"]);

                return RedirectToAction(_pageInfo.MethodName, _pageInfo.ControllerName);
            }
            else
            {
                Response.Redirect(MavenObject.APICodeGeneration + strAppId + "&redirect_uri=" + strUrl);
            }
            return View();
        }
        /// <summary>
        /// The method is used to save the 
        /// </summary>
        /// <param name="Token"></param>
        private void SetUserInformation(string Token)
        {
            AuthMethods getUser = new AuthMethods();
            string jsonUser = @"{'root':" + getUser.GetWithToken(MavenObject.APICurrentUserDetails, Token) + "}";
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonUser);

            HttpContext.Session.SetString("MLUser", doc.SelectSingleNode("//full_name").InnerText);
            HttpContext.Session.SetString("MLAccount", doc.SelectSingleNode("//account_id").InnerText);
            HttpContext.Session.SetString("MLUserEmail", doc.SelectSingleNode("//email_address").InnerText);
            HttpContext.Session.SetString("MLUserId", doc.SelectSingleNode("//id").InnerText);
            HttpContext.Session.SetString("IsPunchClock", doc.SelectSingleNode("//is_punch_clock_user").InnerText);
            HttpContext.Session.SetString("MLPermissions", doc.SelectSingleNode("//account_permission").InnerText);
            HttpContext.Session.SetString("MLBearer", Token);
        }
    }
}
