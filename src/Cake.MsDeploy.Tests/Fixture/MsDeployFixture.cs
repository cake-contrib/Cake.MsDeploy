using Cake.Testing;
using Cake.Testing.Fixtures;

namespace Cake.MsDeploy.Tests.Fixture
{
    internal sealed class MsDeployFixture : ToolFixture<MsDeploySettings>
    {
        public MsDeployFixture() :
            base("msdeploy.exe")
        {
            Environment = FakeEnvironment.CreateWindowsEnvironment(true);
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        
        protected override void RunTool()
        {
            var tool = new MsDeployRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
