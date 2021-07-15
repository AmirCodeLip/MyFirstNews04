using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstNews
{
    public static class SharedItem
    {
        public static Dictionary<string, string> Mimes = new Dictionary<string, string>
        (new List<KeyValuePair<string, string>>{
            new KeyValuePair<string,string>(".jpeg","image/jpeg"),
            new KeyValuePair<string,string>(".jpg","image/jpeg"),
            new KeyValuePair<string,string>(".png","image/png"),
        });




        public static ContentResult JsonContent(object data)
        {
            string result = "";
            if (data is string)
                result = data.ToString();

            else
            {
                result = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore

                });

            }

            return new ContentResult { ContentType = "Application/Json; charset=utf-8", Content = result };
        }



    }
}
