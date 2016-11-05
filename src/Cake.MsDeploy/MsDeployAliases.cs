using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.MsDeploy
{
    /// <summary>
    /// <para>
    /// Contains functionality for working with the MsDeploy.exe (Web Deploy) command line interface (cli).</para>
    /// <para>
    /// In order to use the commands for this alias, MsDeploy v3.6 will already have to be installed on the machine the Cake Script is being executed.
    /// </para>    
    /// See also https://www.microsoft.com/en-us/download/details.aspx?id=43717 
    /// </summary>
    [CakeAliasCategory("Deployment")]
    [CakeNamespaceImport("Cake.MsDeploy")]
    [CakeNamespaceImport("Cake.MsDeploy.Directives")]
    [CakeNamespaceImport("Cake.MsDeploy.Providers.MsDeployProviders")]
    [CakeNamespaceImport("Cake.MsDeploy.Rules")]
    [CakeNamespaceImport("Cake.MsDeploy.Parameters")]
    [CakeNamespaceImport("Cake.MsDeploy.Providers")]
    public static class MsDeployAliases
    {
        /// <summary>
        /// Executes an MsDeploy operation for the given source, destination (optional), and operation settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The MSDeploy settings</param>
        /// <example>
        /// <code>
        ///     var settings = new MsDeploySettings
        ///     {
        ///         Verb = Operation
        ///         Configurations = new[] { "Debug", "Release" },
        ///         OutputDirectory = "./artifacts/",
        ///         Quiet = true
        ///     };
        ///
        ///     MsDeploy(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void MsDeploy(this ICakeContext context, MsDeploySettings settings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var runner = new MsDeployRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(settings);
        }
    }
}
