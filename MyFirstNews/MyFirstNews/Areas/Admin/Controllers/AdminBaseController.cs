using Microsoft.AspNetCore.Mvc;
using MyFirstNews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        public AdminBaseController(ApplicationDbContext context)
        {
            _context = context;
        }
       
    }
}
