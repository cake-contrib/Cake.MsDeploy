using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// File System Content
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:contentPath="c:\inetpub\wwwroot"
    /// </code>
    public class ContentPathProvider : MsDeployProvider
    {

        public override string Type
        {
            get
            {
                return "contentPath";
            }
        }

        /// <summary>
        /// Specify the name of the template file in the site root to use to take the application offline during the sync.
        /// </summary>
        public string AppOfflineTemplate { get; set; }

        /// <summary>
        /// Specify the name of a .NET Framework protected configuration provider available on destination to be used for encryption of destination web.config file.Default provider used is RsaProtectedConfigurationProvider.
        /// </summary>
        public string WebConfigEncryptProvider { get; set; }

        /// <summary>
        /// The ContentPathLib provider does not compare timestamps of files that live under the approot\packages folder.To force Web Deploy to compare timestamps, set this setting to 'true'.
        /// </summary>
        public bool? SyncPackageTimeStamps { get; set; }

        #region DupFinder Exclusion
        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(AppOfflineTemplate))
                sb.AppendFormat(",appOfflineTemplate=\"{0}\"", AppOfflineTemplate);

            if (!string.IsNullOrWhiteSpace(WebConfigEncryptProvider))
                sb.AppendFormat(",webConfigEncryptProvider=\"{0}\"", WebConfigEncryptProvider);

            if (SyncPackageTimeStamps.HasValue)
                sb.AppendFormat(",syncPackageTimeStamps={0}", SyncPackageTimeStamps);
        }
        #endregion
    }
}
