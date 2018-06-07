using CakeTickBoard.Models;
using CakeTickBoard.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CakeTickBoard.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var allUsers =
                    from user in _context.Users.ToList()
                    select new UserViewModel()
                    {
                        UserName = user.Email,
                        CakeTickCount = user.CakeTickCount,
                        Rank = _context.Rankings.First(r => 
                                    user.CakeTickCount >= r.LowerBoundPoints && 
                                    user.CakeTickCount <= r.UpperBoundPoints)?.RankName 
                                ?? _context.Rankings.First().RankName
                    };

            return View(allUsers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}