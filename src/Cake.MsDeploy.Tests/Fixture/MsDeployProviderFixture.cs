using Cake.MsDeploy.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Tests.Fixture
{
    public class MsDeployProviderFixture : MsDeployProvider
    {
        /// <summary>
        /// MsDeploy Fixture 
        /// </summary>
        public override string Type
        {
            get { return "msdeploy-fixture"; }
        }
    }
}
