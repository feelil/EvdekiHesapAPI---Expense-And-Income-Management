using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace Butce.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Authorize]
        public List<string> List()
        {
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var userName = prinicpal.Claims.Where(c => c.Type == "UserName").Select(c => c.Value).SingleOrDefault();
            var userPassword = prinicpal.Claims.Where(c => c.Type == "Password").Select(c => c.Value).SingleOrDefault();

            List<string> orders = new List<string>();

            orders.Add("Elma");
            orders.Add("Armut");
            orders.Add("Erik");

            return orders;
        }
    }
}
