using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Automatic destination
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:auto
    /// </code>
    public class AutoProvider : MsDeployProvider
    {
        public AutoProvider()
        {
            RequirePath = false;
        }

        public override string Type
        {
            get
            {
                return "auto";
            }
        }
    }
}
