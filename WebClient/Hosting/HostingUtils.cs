using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebClient.Hosting
{
    static class HostingUtils
    {
        public const string VirtualLocation = "Virtual";
        
        //(Dll location, aspx file path relative to project)
        public static KeyValuePair<string,string> ParseVirtualPath(string virtualPath)
        {
            //~/Virtual/Datoteka.aspx
            var items = virtualPath.Split('/');

            var dllLocation = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;

            var formModuleDllsLocation = Path.Combine(GoBackNDirectories(dllLocation, 3), "FormModuleDlls");

            string fileName = items[2].Substring(0, items[2].IndexOf('.'));

            var path = Path.Combine(formModuleDllsLocation,$"{fileName}.dll");

            var aspxPath = $"{fileName}.FormModule.{fileName}.aspx";

            return new KeyValuePair<string, string>(path, aspxPath);
        }
        
        private static string GetFolderPath(string startPath, string targetFolderName)
        {
            string parentsParent = GetParentDirectory(GetParentDirectory(startPath));

            if (parentsParent == null)
            {
                return null;
            }

            var dirs = Directory.GetDirectories(parentsParent);
            foreach (var dir in dirs)
            {
                if (Path.GetDirectoryName(dir) == targetFolderName)
                {
                    return dir;
                }
                return GetFolderPath(dir, targetFolderName);
            }

            return null;
        }

        private static string GetParentDirectory(string path)
        {
            return Directory.GetParent(path).FullName;
        }

        private static string GoBackNDirectories(string startPath,int n)
        {
            
            for (int i = 0; i < n; i++)
            {
                startPath = GetParentDirectory(startPath);
            }

            return startPath;
        }
    }
}