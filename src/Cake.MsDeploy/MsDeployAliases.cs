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
    [CakeAliasCategory("MsDeploy")]
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
        ///         Verb = Operation.Sync,
        ///         RetryAttempts = 5,
        ///         RetryInterval = 5000,
        ///         Source = new PackageProvider
        ///         {
        ///             Direction = MsDeploy.Providers.Direction.source,
        ///             Path = "./src/Application.zip"
        ///         },
        ///         Destination = new AutoProvider
        ///         {
        ///             Direction = MsDeploy.Providers.Direction.dest,
        ///             IncludeAcls = false,
        ///             AuthenticationType = MsDeploy.Providers.AuthenticationScheme.NTLM,
        ///             ComputerName = "cake.computerName.com",
        ///             TempAgent = true
        ///          },
        ///          AllowUntrusted = true,
        ///          PreSyncCommand = "%windir%\\System32\\inetsrv\\appcmd.exe stop APPPOOL NameOfAppPool",
        ///          PostSyncCommand = "%windir%\\System32\\inetsrv\\appcmd.exe start APPPOOL NameOfAppPool",
        ///          WhatIf = true,
        ///          SetParams = new List&lt;SetParameter&gt;
        ///          {
        ///             new SetParameter
        ///             {
        ///                 Name = "IIS Web Application Name",
        ///                 Value = "www.cake.com"
        ///             }
        ///          }
        ///      };
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
