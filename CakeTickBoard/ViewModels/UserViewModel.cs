﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CakeTickBoard.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CakeTickCount { get; set; }
        public string Rank { get; set; }
    }
}