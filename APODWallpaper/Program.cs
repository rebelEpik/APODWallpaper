using HtmlAgilityPack;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace APODWallpaper
{
    public class Program
    {
        static string url = @"https://apod.nasa.gov/apod/astropix.html";
        public static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var image = doc.DocumentNode.SelectSingleNode("//html//body//img").Attributes["src"].Value;
            var temp = image.Split('/');
            var filename = temp[2];
            var imageURL = "https://apod.nasa.gov/apod/" + image;
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(imageURL), filename);

                }
                Uri myUri = new Uri(imageURL, UriKind.Absolute);
                Wallpaper.Set(myUri, Wallpaper.Style.Fill);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }

    
}
