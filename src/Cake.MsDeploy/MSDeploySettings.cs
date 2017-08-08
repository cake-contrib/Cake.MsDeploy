using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.MsDeploy.Directives;
using Cake.MsDeploy.Parameters;
using Cake.MsDeploy.Providers;
using Cake.MsDeploy.Rules;
using System.Collections.Generic;

namespace Cake.MsDeploy
{
    /// <summary>
    /// Contains settings used by <see cref="MsDeployRunner" />.
    /// </summary>
    public class MsDeploySettings : ToolSettings
    {
        /// <summary>
        /// Action to perform (required).
        /// </summary>
        public Operation Verb { get; set; }

        /// <summary>
        /// The source object for the operation (required).
        /// </summary>
        public MsDeployProvider Source { get; set; }

        /// <summary>
        /// The destination object for the operation. 
        /// </summary>
        public MsDeployProvider Destination { get; set; }

        /// <summary>
        /// Collection of Parameters to DECLARE during a sync operation
        /// </summary>
        public IEnumerable<DeclareParameter> DeclareParams { get; set; }

        /// <summary>
        /// Collection of Parameters to SET during a sync operation
        /// </summary>
        public IEnumerable<SetParameter> SetParams { get; set; }

        /// <summary>
        /// Includes parameter declarations from an XML file.
        /// </summary>
        public FilePath DeclareParamFile { get; set; }

        /// <summary>
        /// Applies parameter settings from an XML file
        /// </summary>
        public FilePath SetParamFile { get; set; }

        /// <summary>
        /// Collection parameters to remove from the declare list
        /// </summary>
        public IEnumerable<string> RemoveParams { get; set; }

        /// <summary>
        /// Enables the specified link extension(s).
        /// </summary>
        public IEnumerable<string> EnableLinks { get; set; }

        /// <summary>
        /// Collection of link extensions to disable during a sync operation
        /// </summary>
        public IEnumerable<string> DisableLinks { get; set; }

        /// <summary>
        /// Enables the specified synchronization rule(s).
        /// </summary>
        public IEnumerable<string> EnableRules { get; set; }

        /// <summary>
        ///  Disables the specified synchronization rule(s).
        /// </summary>
        public IEnumerable<string> DisableRules { get; set; }

        /// <summary>
        /// Specifies collection of attribute replacement rules
        /// </summary>
        public IEnumerable<ReplacementRule> ReplacementRules { get; set; }

        /// <summary>
        /// The number of times a provider will retry after a failed action (not all providers support retrying). Defaults to 5.
        /// </summary>
        public int? RetryAttempts { get; set; }

        /// <summary>
        /// Interval in milliseconds between retry attempts (-retryAttempts). The default is 1000.
        /// </summary>
        public int? RetryInterval { get; set; }

        /// <summary>
        /// Collection of SkipDirectives that specifies object(s) to skip during synchronization.
        /// </summary>
        public IEnumerable<SkipDirective> SkipDirectives { get; set; }

        /// <summary>
        /// Specifies collection of specified skip directive(s) to enable.
        /// </summary>
        public string EnableSkipDirective { get; set; }

        /// <summary>
        /// Specifies collection of specified skip directive(s) to disable.
        /// </summary>
        public string DisableSkipDirective { get; set; }

        /// <summary>
        /// Enables more verbose output.
        /// </summary>
        public bool? Verbose { get; set; }

        /// <summary>
        /// Displays what would have happened without actually performing any operations.
        /// </summary>
        public bool? WhatIf { get; set; }

        /// <summary>
        /// Disables saving to the application store during a sync
        /// </summary>
        public bool? DisableAppStore { get; set; }

        /// <summary>
        /// An XPath expression to apply to XML output.
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// True to  Return results in XML format.
        /// </summary>
        public bool? Xml { get; set; }

        /// <summary>
        /// Allow untrusted server certificate when using SSL.
        /// </summary>
        public bool? AllowUntrusted { get; set; }

        /// <summary>
        /// This setting is useful when you want to copy only 
        /// the files whose content has changed, and ignore 
        /// files that have the same content but different time stamps.
        /// </summary>
        public bool? UseCheckSum { get; set; }

        /// <summary>
        ///true to show secure attributes in XML output instead of hiding them
        /// </summary>
        public bool? ShowSecure { get; set; }

        /// <summary>
        /// Command to run on the remote server before a sync operation starts
        /// </summary>
        public CommandProvider PreSyncCommand { get; set; }

        /// <summary>
        /// Command to run on the remote server after a sync operation completes
        /// </summary>
        public CommandProvider PostSyncCommand { get; set; }

    }
}
