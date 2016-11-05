using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Used to deploy ASP.NET Core libraries that live outside the content root folder.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:contentPathAspNetCore="c:\site\wwwroot"
    /// </code>
    public class ContentPathAspNetCoreProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "contentPathAspNetCore";
            }
        }
    }
}
