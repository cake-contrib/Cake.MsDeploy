using Cake.MsDeploy.Directives;
using System.Collections.Generic;
using Xunit;

namespace Cake.MsDeploy.Tests.Unit.Directives
{
    public class SkipDirectiveTests
    {
        public sealed class TheToCommandLineArgument
        {
            [Fact]
            public void Should_Throw_If_Context_Is_Null()
            {
                // Given
                var rule = new SkipDirective();

                // When
                var result = Record.Exception(() => rule.AppendCommandLineArgument(null));

                // Then
                AssertEx.IsArgumentNullException(result, "sb");
            }
            

            [Theory]
            [MemberData(nameof(SkipDirectiveData))]
            public void Should_Append_Options(SkipDirective directive, string expected)
            {
                //Given --> When
                var actual = directive.ToCommandLineArgument();

                //Then
                Assert.Equal(expected, directive.ToCommandLineArgument());
            }

            public static IEnumerable<object[]> SkipDirectiveData()
            {
                return new List<object[]>
                {
                    new object[]
                    {
                        new SkipDirective {  ObjectName = "contentPath", AbsolutePath = "C:\\fake\\path"  },  // <------------- Indivdual Property to test
                        "-skip:objectName=contentPath,absolutePath=\"C:\\fake\\path\"",                    // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new SkipDirective { SkipAction = SkipAction.Update, ObjectName = "windowsAuthentication"  },  // <------------- Indivdual Property to test
                        "-skip:skipAction=Update,objectName=windowsAuthentication",                     // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new SkipDirective { ObjectName = "webConfig", KeyAttribute = "Key attribute"},   // <------------- Indivdual Property to test
                        "-skip:objectName=webConfig,keyAttribute=\"Key attribute\"",                       // <------------- Expected  Result
                    },

                    new object[]
                    {
                        new SkipDirective { ObjectName = "destPath", XPath = "/web.config"  },  // <------------- Indivdual Property to test
                         "-skip:objectName=destPath,xPath=\"/web.config\"",                       // <------------- Expected  Result
                    },
                    
                    new object[]
                    {
                        new SkipDirective { ObjectName = "virtualdirectory", SkipAction = SkipAction.Update, AbsolutePath = "C:\\wwwroot", XPath = "//web.config", KeyAttribute = "Description"},  // <------------- Combined Properties to test
                        "-skip:skipAction=Update,objectName=virtualdirectory,absolutePath=\"C:\\wwwroot\",xPath=\"//web.config\",keyAttribute=\"Description\""               // <------------- Expected  Result
                    }
                };
            }
        }
    }
}
