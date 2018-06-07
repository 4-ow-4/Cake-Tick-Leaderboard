﻿using CakeTickBoard.Models;
using System.Linq;
using System.Web.Mvc;

namespace CakeTickBoard.Controllers.Base
{
    public class ApplicationBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = user.FullName;
                    ViewData.Add("FullName", fullName);
                }
            }
            base.OnActionExecuted(filterContext);
        }

        public ApplicationBaseController()
        {
        }
    }
}