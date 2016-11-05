using Xunit;

namespace Cake.MsDeploy.Tests.Unit
{
    public sealed class MsDeploySettingsTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Set_Verb_To_Sync_By_Default()
            {
                //Arrange
                var settings = new MsDeploySettings();

                //Act ==> Assert
                Assert.Equal<Operation>(settings.Verb, Operation.Sync);
            }
        }
    }
}
