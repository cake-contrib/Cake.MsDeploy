using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Signed Assembly GAC Installer
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:gacInstall="c:\Project\bin\debug\assemblytogac.dll"
    /// </code>
    public class GacInstallProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "gacInstall";
            }
        }
    }
}
