using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Modifies IIS inheritance rules for different authentication settings to either allow  or deny them to be overridden in a site's web.config file.
    /// </summary>
    /// <code>
    ///     msdeploy.exe -verb:sync -source:apphostauthoverride -dest:apphostauthoverride=siteName;anonymousAuthentication=Allow
    /// </code>
    public class AppHostAuthOverrideProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appHostAuthOverride";
            }
        }

        /// <summary>
        /// Used to specify which .NET framework version to use with given provider.
        /// </summary>
        public string NetFxVersion { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(NetFxVersion))
                sb.AppendFormat(",netFxVersion=\"{0}\"", NetFxVersion);
        }
    }
}
