using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.MsDeploy
{
    /// <summary>
    /// The MSDeploy Runner
    /// </summary>
    public sealed class MsDeployRunner : Tool<MsDeploySettings>
    {
        private const string _MsDeployFilePath = @"IIS/Microsoft Web Deploy V3/msdeploy.exe";

        private readonly ICakeEnvironment _Environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsDeployRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="runner">The runner.</param>
        /// <param name="tool">The tool locator.</param>
        public MsDeployRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner runner, IToolLocator tool)
            : base(fileSystem, environment, runner, tool)
        {
            _Environment = environment;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "msdeploy.exe", "msdeploy" };
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override string GetToolName()
        {
            return "Web Deploy";
        }

        /// <summary>
        /// Gets the alternative tool paths.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(MsDeploySettings settings)
        {
            return new FilePath[]
            {
                _Environment.GetSpecialPath(SpecialPath.ProgramFiles).CombineWithFilePath(_MsDeployFilePath),
                _Environment.GetSpecialPath(SpecialPath.ProgramFilesX86).CombineWithFilePath(_MsDeployFilePath)
            };
        }

        private ProcessArgumentBuilder GetArguments(MsDeploySettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // Operation or Verb 
            builder.Append("-verb:{0}", settings.Verb.ToString().ToLower());

            // Source ?
            if(settings.Source != null)            
                builder.Append(settings.Source.ToCommandLineArgument());

            // Destination ?
            if (settings.Destination != null)
                builder.Append(settings.Destination.ToCommandLineArgument());

            // DeclareParams ?
            if(settings.DeclareParams != null && settings.DeclareParams.Any())
            {
                foreach (var declareParam in settings.DeclareParams)
                    builder.Append(declareParam.ToCommandLineArgument());
            }

            // SetParams ?
            if (settings.SetParams != null && settings.SetParams.Any())
            {
                foreach (var setParam in settings.SetParams)
                    builder.Append(setParam.ToCommandLineArgument());
            }

            // DeclareParam File
            if (settings.DeclareParamFile != null)            
                builder.Append("-declareParamFile:\"{0}\"", settings.DeclareParamFile.MakeAbsolute(_Environment).FullPath);

            // SetParam File
            if (settings.SetParamFile != null)
                builder.Append("-setParamFile:\"{0}\"", settings.SetParamFile.MakeAbsolute(_Environment).FullPath);

            // RemoveParams ?
            if (settings.RemoveParams != null && settings.RemoveParams.Any())
            {
                foreach (var removeParam in settings.RemoveParams)
                    builder.Append("-removeParam:{0}", removeParam);
            }

            // EnableLinks ?
            if (settings.EnableLinks != null && settings.EnableLinks.Any())
			{
				foreach (var enableLink in settings.EnableLinks)
					builder.Append("-enableLink:{0}", enableLink);
			}

			// DisableLinks ?
			if (settings.DisableLinks != null && settings.DisableLinks.Any())
			{
				foreach (var disableLink in settings.EnableLinks)
					builder.Append("-disableLink:{0}", disableLink);
			}

            // EnableRules ?
            if (settings.EnableRules != null && settings.EnableRules.Any())
                builder.Append("-enableRule:{0}", string.Join<string>(",", settings.EnableRules));

            // DisableRules ?
            if (settings.DisableRules != null && settings.DisableRules.Any())
                builder.Append("-disableRule:{0}", string.Join<string>(",", settings.DisableRules));

            // ReplacementRules ?
            if (settings.ReplacementRules != null && settings.ReplacementRules.Any())
            {
                foreach (var replacmentRule in settings.ReplacementRules)
                    builder.Append(replacmentRule.ToCommandLineArgument());
            }

            // RetryAttempts ?
            if (settings.RetryAttempts.HasValue)
                builder.Append("-retryAttempts:{0}", settings.RetryAttempts);

            // RetryInterval ?
            if (settings.RetryInterval.HasValue)
                builder.Append("-retryInterval:{0}", settings.RetryInterval);

            // SkipDirectives ?
            if (settings.SkipDirectives != null && settings.SkipDirectives.Any())
            {
                foreach (var skipDirective in settings.SkipDirectives)
                    builder.Append(skipDirective.ToCommandLineArgument());
            }

            // EnableSkipDirective?
            if (!string.IsNullOrWhiteSpace(settings.EnableSkipDirective))
                builder.Append("-enableSkipDirective:{0}", settings.EnableSkipDirective);

            // EnableSkipDirective?
            if (!string.IsNullOrWhiteSpace(settings.DisableSkipDirective))
                builder.Append("-disableSkipDirective:{0}", settings.DisableSkipDirective);

            // Verbose ?
            if (settings.Verbose.GetValueOrDefault(false))
                builder.Append("-verbose");

            // WhatIf ?
            if (settings.WhatIf.GetValueOrDefault(false))
                builder.Append("-whatif");

            // DisableAppStore ?
            if (settings.DisableAppStore.GetValueOrDefault(false))
                builder.Append("-disableAppStore");

            // XPath ?
            if (!string.IsNullOrWhiteSpace(settings.XPath))
                builder.Append("-xpath:\"{0}\"", settings.XPath);

            // Xml ?
            if (settings.Xml.GetValueOrDefault(false))
                builder.Append("-xml");

            // AllowUntrusted ?
            if (settings.AllowUntrusted.GetValueOrDefault(false))
                builder.Append("-allowUntrusted");

            // UseCheckSum ?
            if (settings.UseCheckSum.GetValueOrDefault(false))
                builder.Append("-useCheckSum");

            // ShowSecure?
            if (settings.ShowSecure.GetValueOrDefault(false))
                builder.Append("-showSecure");

            // PreSyncCommand ?
            if (!string.IsNullOrWhiteSpace(settings.PreSyncCommand))
                builder.Append("-preSync:runCommand=\"{0}\"", settings.PreSyncCommand);

            // PreSyncCommand ?
            if (!string.IsNullOrWhiteSpace(settings.PostSyncCommand))
                builder.Append("-postSync:runCommand=\"{0}\"", settings.PostSyncCommand);

            return builder;
        }

        /// <summary>
        /// Runs the MSDeploy Tool with the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(MsDeploySettings settings)
        {
            if (settings == null)            
                throw new ArgumentNullException(nameof(settings));            

            Run(settings, GetArguments(settings));
        }
    }
}
