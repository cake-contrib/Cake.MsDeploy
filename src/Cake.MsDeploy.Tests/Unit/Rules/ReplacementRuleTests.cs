using Cake.MsDeploy.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit.Rules
{
    public sealed class ReplacementRuleTests
    {
        public sealed class TheToCommandLineArgument
        {
            [Fact]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                var rule = new ReplacementRule();

                // When
                var result = Record.Exception(() => rule.AppendCommandLineArgument(null));

                // Then
                Assert.IsArgumentNullException(result, "sb");
            }

            [Fact]
            public void Should_Throw_If_ObjectName_Is_Null_Or_Empty()
            {
                // Given
                var rule = new ReplacementRule();
                var sb = new StringBuilder();

                // When --> Then
                Assert.Throws<NullReferenceException>(() => { rule.AppendCommandLineArgument(sb); });
            }

            [Theory]
            [MemberData("ReplacementRuleData")]
            public void Should_Append_Options(ReplacementRule rule, string expected)
            {
                //Given --> When
                var actual = rule.ToCommandLineArgument();

                //Then
                Assert.Equal(expected, rule.ToCommandLineArgument());
            }

            public static IEnumerable<object[]> ReplacementRuleData()
            {
                return new List<object[]>
                {
                    new object[]
                    {
                        new ReplacementRule { ObjectName = "binding", ScopeAttributeName = "Image"  },  // <------------- Indivdual Property to test
                        "-replace:objectName=binding,scopeAttributeName=\"Image\"",                    // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new ReplacementRule { ObjectName = "binding", ScopeAttributeValue = "jpg"  },  // <------------- Indivdual Property to test
                        "-replace:objectName=binding,scopeAttributeValue=\"jpg\"",                     // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new ReplacementRule { ObjectName = "binding", TargetAttributeName = "png"  },   // <------------- Indivdual Property to test
                        "-replace:objectName=binding,targetAttributeName=\"png\"",                       // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new ReplacementRule { ObjectName = "binding", Match = "true"  },  // <------------- Indivdual Property to test
                         "-replace:objectName=binding,match=\"true\"",                       // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new ReplacementRule { ObjectName = "binding", Value = "false" },  // <------------- Indivdual Property to test
                        "-replace:objectName=binding,replace=\"false\"",                  // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new ReplacementRule { ObjectName = "virtualdirectory", ScopeAttributeName = "physicalPath", ScopeAttributeValue = "Image", TargetAttributeName ="allowSubDirConfig", Match = "true", Value = "false" },  // <------------- Combined Properties to test
                        "-replace:objectName=virtualdirectory,scopeAttributeName=\"physicalPath\",scopeAttributeValue=\"Image\",targetAttributeName=\"allowSubDirConfig\",match=\"true\",replace=\"false\""               // <------------- Expected  Result
                    }
                };
            }
        }    
    }
}
