using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace WebClient.Hosting
{
    class CustomVirtualPathProvider : VirtualPathProvider
    {
       private bool IsCustomPath(string virtualPath)
       {
            var appPath = VirtualPathUtility.ToAppRelative(virtualPath);

            return appPath.StartsWith($"~/{HostingUtils.VirtualLocation}/",StringComparison.InvariantCultureIgnoreCase);
       }

        public override bool FileExists(string virtualPath)
        {
            if (IsCustomPath(virtualPath))
            {
                return true;
            }
            else
            {
                return base.FileExists(virtualPath);
            }
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsCustomPath(virtualPath))
            {
                return new CustomVirtualFile(virtualPath);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
           
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsCustomPath(virtualPath))
            {
                return null;
            }
            else
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }
    }
}