using Microsoft.AspNetCore.Mvc;
using MyFirstNews.Data;
using MyFirstNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstNews.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FileController(ApplicationDbContext context)
        {
            _context = context;
        }

        //File/GetImg/ED07B425-7F0A-49BB-937E-FA9E2ABFCCC3
        public IActionResult GetImg(Guid? Id)
        {
            NewsImage img = null;
            if (!Id.HasValue || (img = _context.NewsImages.FirstOrDefault(x=>x.Id==Id)) == null)
                return NotFound();





            return File(System.IO.File.ReadAllBytes(img.FullPath),SharedItem.Mimes[img.Extension.ToLower()]);
        }



    }
}
