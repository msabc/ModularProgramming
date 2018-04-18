using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Hosting
{
    static class HostingUtils
    {
        public const string VirtualLocation = "Virtual";

        public static List<string> ParseVirtualPath(string url)
        {
            //~/Virtual/Folder/Datoteka.aspx
            var items = url.Split('/');


            return items.Skip(2).ToList();
        }
    }
}