using Cake.MsDeploy.Providers;

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
