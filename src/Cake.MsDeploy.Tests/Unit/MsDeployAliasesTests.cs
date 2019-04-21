using Cake.Core;
using NSubstitute;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit
{

    public sealed class MsDeployAliasesTests
    {
        public sealed class TheMsDeployMethod
        {
            [Fact]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                var context = Substitute.For<ICakeContext>();

                // When
                var result = Record.Exception(() => MsDeployAliases.MsDeploy(null, null));

                // Then
                AssertEx.IsArgumentNullException(result, "context");
            }

            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var context = Substitute.For<ICakeContext>();

                // When
                var result = Record.Exception(() => MsDeployAliases.MsDeploy(context, null));

                // Then
                AssertEx.IsArgumentNullException(result, "settings");
            }            
        }
    }
}