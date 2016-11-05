using Cake.MsDeploy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit.Parameters
{
    public class SetParameterTestsTests
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
                var setParameter = new SetParameter();

                // When...Then
                var result = Record.Exception(() => setParameter.AppendCommandLineArgument(new StringBuilder()));

                // Then
                Assert.IsExceptionWithMessage<NullReferenceException>(result, "Name is required when using the SetParameter option.");
            }


            [Theory]
            [MemberData("SetParameterData")]
            public void Should_Append_Options(SetParameter setParameter, string expected)
            {
                //Given --> When
                var actual = setParameter.ToCommandLineArgument();

                //Then
                Assert.Equal(expected, setParameter.ToCommandLineArgument());
            }

            public static IEnumerable<object[]> SetParameterData()
            {
                return new List<object[]>
                {
                    new object[]
                    {
                        new SetParameter {  Name = "OracleDbPassword", Description = "Oracle Database Password", Kind = ParameterKind.ProviderPath, Scope = "app.config", Match = "12;10;29",  Value = "tiger" },  // <------------- Combined Properties to test
                        "-setParam:name=\"OracleDbPassword\",kind=\"ProviderPath\",scope=\"app.config\",match=\"12;10;29\",value=\"tiger\",description=\"Oracle Database Password\""                    // <------------- Expected  Result
                    }
                };
            }
        }
    }
}
