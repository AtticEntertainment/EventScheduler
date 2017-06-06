using AtticEntertainment.Models;
using System.Web.Mvc;

namespace AtticEntertainment.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
            // GET: Home/10
        public ActionResult Schedule(int? id)
        {
            AtticEntertainmentContext db = new AtticEntertainmentContext();
            if (id.HasValue)
            {
                if(db.Events.Find(id) == null)
                {
                    Response.StatusCode = 404;
                    return new HttpNotFoundResult();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View("List");
            }
        }
    }
}