﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaimaProje2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}