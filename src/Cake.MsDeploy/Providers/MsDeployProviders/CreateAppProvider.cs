using System;
using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Defines an application in the IIS configuration system.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:sync -source:createApp -dest:createApp="Default Web Site/My Application"
    /// </code>
    public class CreateAppProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "createApp";
            }
        }

        /// <summary>
        /// Used to specify which .NET framework version to use with given provider
        /// </summary>
        public string ManagedRuntimeVersion { get; set; }

        /// <summary>
        /// Set enable32BitAppOnWin64 to true or false in order to validate if the destination application pool matches.The value will not be set, it will only be compared.
        /// </summary>
        public bool? Enable32BitAppOnWin64 { get; set; }

        /// <summary>
        /// Set managedPipelineMode to Classic or Integrated in order to validate if the destination application pool matches.
        /// </summary>
        public AppPoolPipelineMode? ManagedPipelineMode { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if(!string.IsNullOrWhiteSpace(ManagedRuntimeVersion))
                sb.AppendFormat(",managedRuntimeVersion=\"{0}\"", ManagedRuntimeVersion);

            if (Enable32BitAppOnWin64.HasValue)
                sb.AppendFormat(",enable32BitAppOnWin64={0}", Enable32BitAppOnWin64);

            if (ManagedPipelineMode.HasValue)
                sb.AppendFormat(",managedPipelineMode={0}", ManagedPipelineMode);
        }
    }
}