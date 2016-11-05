using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Web Application
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:iisApp="Default Web Site/My Application"
    /// </code>
    public class IisAppProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "iisApp";
            }
        }

        /// <summary>
        /// A true or false value for the 'SkipAppCreation' setting.
        /// </summary>
        public bool? SkipAppCreation { get; set; }

        /// <summary>
        /// Provider setting used to specify which .NET framework version to use with given provider.
        /// </summary>
        public string ManagedRuntimeVersion { get; set; }

        /// <summary>
        /// Set enable32BitAppOnWin64 to true or false in order to validate if the destination application pool
        /// </summary>
        public bool? Enable32BitAppOnWin64 { get; set; }

        /// <summary>
        /// Set managedPipelineMode to Classic or Integrated in order to validate if the destination application
        /// </summary>
        public string ManagedPipelineMode { get; set; }

        /// <summary>
        /// Specify the name of the template file in the site root to use to take the application offline during
        /// </summary>
        public string AppOfflineTemplate { get; set; }

        /// <summary>
        /// Specify the name of a .NET Framework protected configuration provider available on destination to be
        /// </summary>
        public string WebConfigEncryptProvider { get; set; }

        /// <summary>
        /// This setting is used by the ContentPathLib provider.  By default, the ContentPathLib provider does not
        /// </summary>
        public string SyncPackageTimeStamps { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (SkipAppCreation.HasValue)
                sb.AppendFormat(",skipAppCreation={0}", SkipAppCreation);

            if (!string.IsNullOrWhiteSpace(ManagedRuntimeVersion))
                sb.AppendFormat(",managedRuntimeVersion=\"{0}\"", ManagedRuntimeVersion);

            if (Enable32BitAppOnWin64.HasValue)
                sb.AppendFormat(",enable32BitAppOnWin64={0}", Enable32BitAppOnWin64);

            if (!string.IsNullOrWhiteSpace(ManagedPipelineMode))
                sb.AppendFormat(",managedPipelineMode=\"{0}\"", ManagedPipelineMode);

            if (!string.IsNullOrWhiteSpace(AppOfflineTemplate))
                sb.AppendFormat(",appOfflineTemplate=\"{0}\"", AppOfflineTemplate);

            if (!string.IsNullOrWhiteSpace(WebConfigEncryptProvider))
                sb.AppendFormat(",webConfigEncryptProvider=\"{0}\"", WebConfigEncryptProvider);

            if (!string.IsNullOrWhiteSpace(SyncPackageTimeStamps))
                sb.AppendFormat(",syncPackageTimeStamps=\"{0}\"", SyncPackageTimeStamps);
        }
    }
}
