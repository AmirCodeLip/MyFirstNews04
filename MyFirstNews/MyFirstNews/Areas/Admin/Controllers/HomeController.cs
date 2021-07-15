using Microsoft.AspNetCore.Mvc;
using MyFirstNews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstNews.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public HomeController(ApplicationDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
       
    }
}
