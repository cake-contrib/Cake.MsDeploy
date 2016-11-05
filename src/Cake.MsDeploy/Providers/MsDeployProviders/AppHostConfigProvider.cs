using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// IIS 7 configuration
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:appHostConfig="Default Web Site"
    /// </code>
    public class AppHostConfigProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appHostConfig";
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

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(AppOfflineTemplate))
                sb.AppendFormat(",appOfflineTemplate=\"{0}\"", AppOfflineTemplate);

            if (!string.IsNullOrWhiteSpace(WebConfigEncryptProvider))
                sb.AppendFormat(",webConfigEncryptProvider=\"{0}\"", WebConfigEncryptProvider);
        }
    }
}
