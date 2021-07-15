using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstNews.Data;
using MyFirstNews.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstNews.Areas.Admin.Controllers
{

    public class UploadController : AdminBaseController
    {
        public UploadController(ApplicationDbContext context) : base(context)
        {

        }




        [HttpPost]
        public async Task<IActionResult> SaveFile(IFormFile file)
        {
            var data = new NewsImage();
            data.Extension = Path.GetExtension(file.FileName);

            using (var fs = new FileStream(data.FullPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }



            _context.Add(data);
            await _context.SaveChangesAsync();


            return SharedItem.JsonContent(new
            {

                data.Id

            });
        }





    }
}
