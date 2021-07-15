using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstNews.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [NotMapped]
        public string ShortDescription
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Description) || Description.Length < 50)
                {
                    return Description;
                }
                else
                {
                    return Description.Substring(0, 49);
                }
            }

        }



        public ICollection<NewsAndTag> NewsAndTags { get; set; }
        public ICollection<NewsImage> NewsImages { get; set; }





    }
}
