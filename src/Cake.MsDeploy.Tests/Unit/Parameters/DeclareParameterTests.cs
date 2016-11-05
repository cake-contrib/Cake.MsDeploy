using Cake.MsDeploy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit.Parameters
{
    public class DeclareParameterTests
    {
        public sealed class TheToCommandLineArgument
        {
            [Fact]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                var declareParameter = new DeclareParameter();

                // When
                var result = Record.Exception(() => declareParameter.AppendCommandLineArgument(null));

                // Then
                Assert.IsArgumentNullException(result, "sb");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_Null_or_Empty()
            {
                // Given
                var declareParameter = new DeclareParameter();

                // When...Then
                var result = Record.Exception(() => declareParameter.AppendCommandLineArgument(new StringBuilder()));

                // Then
                Assert.IsExceptionWithMessage<NullReferenceException>(result, "Name is required when using the DeclareParameter option.");
            }


            [Theory]
            [MemberData("DeclareParameterData")]
            public void Should_Append_Options(DeclareParameter declareParameter, string expected)
            {
                //Given --> When
                var actual = declareParameter.ToCommandLineArgument();

                //Then
                Assert.Equal(expected, declareParameter.ToCommandLineArgument());
            }

            public static IEnumerable<object[]> DeclareParameterData()
            {
                return new List<object[]>
                {
                    new object[]
                    {
                        new DeclareParameter {  Name = "OracleDbUserName", Description = "Oracle Database Username", Kind = ParameterKind.ProviderPath, Scope = "app.config", Match = "12;10;29",  DefaultValue = "scott",  Tags = new string[] { "Oracle", "DBA" }  },  // <------------- Combined Properties to test
                        "-declareParam:name=\"OracleDbUserName\",kind=\"ProviderPath\",scope=\"app.config\",match=\"12;10;29\",defaultValue=\"scott\",description=\"Oracle Database Username\",tags=\"Oracle,DBA\""                    // <------------- Expected  Result
                    }
                };
            }
        }
    }
}
