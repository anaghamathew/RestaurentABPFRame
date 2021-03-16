using System.Threading.Tasks;
using Abp.Web.Security.AntiForgery;
using Microsoft.AspNetCore.Antiforgery;
using RestaurentProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace RestaurentProject.Web.Host.Controllers
{
    public class AntiForgeryController : RestaurentProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(IAntiforgery antiforgery, IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiforgery = antiforgery;
            _antiForgeryManager = antiForgeryManager;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }

        public void SetCookie()
        {
            _antiForgeryManager.SetCookie(HttpContext);
        }
    }
}
