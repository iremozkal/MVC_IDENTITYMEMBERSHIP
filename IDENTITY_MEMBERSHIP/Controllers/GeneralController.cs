﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDENTITY_MEMBERSHIP.Controllers
{
    public class GeneralController : Controller
    {
        //
        // GET: /General/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
