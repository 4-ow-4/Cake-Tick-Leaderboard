using CakeTickBoard.Models;
using CakeTickBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CakeTickBoard.ApiControllers
{
    public class LeaderoardController : ApiController
    {
        private ApplicationDbContext _context;

        public LeaderoardController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/leaderboard/users")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var allUsers =
                    from user in _context.Users.ToList()
                    select new UserViewModel()
                    {
                        UserId = user.UserId,
                        UserName = user.FullName,
                        CakeTickCount = user.CakeTickCount,
                        Rank = _context.Rankings.First(r =>
                                    user.CakeTickCount >= r.LowerBoundPoints &&
                                    user.CakeTickCount <= r.UpperBoundPoints)?.RankName
                                ?? _context.Rankings.First().RankName
                    };

            return await Task.FromResult(Ok(allUsers));
        }
    }
}
