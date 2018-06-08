using CakeTickBoard.Controllers.Base;
using CakeTickBoard.Models;
using CakeTickBoard.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CakeTickBoard.Controllers
{
    public class HomeController : ApplicationBaseController
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> UserManager { get; set; }

        public HomeController()
        {
            _context = new ApplicationDbContext();

            UserManager = 
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(
                        _context));
        }

        public ActionResult Index()
        {
            var allUsers =
                    from user in _context.Users.ToList()
                    select new UserViewModel()
                    {
                        UserName = user.FullName,
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

        [Authorize]
        public async Task<ActionResult> AddTick()
        {
            var user = 
                 await UserManager.FindByIdAsync(
                     System.Web.HttpContext.Current.User.Identity.GetUserId());

            user.CakeTickCount += 
                user.CakeTickCount < int.MaxValue 
                ? 1 
                : 0;

            await _context.SaveChangesAsync();

            return Redirect("Index");
        }

        [Authorize]
        public async Task<ActionResult> RemoveTick()
        {
            var user =
                 await UserManager.FindByIdAsync(
                     System.Web.HttpContext.Current.User.Identity.GetUserId());

            user.CakeTickCount -=
                user.CakeTickCount > 0
                ? 1
                : 0;

            await _context.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}