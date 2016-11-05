using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// The appPoolNetFx provider displays or sets the .NET Framework version of an IIS application pool.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:appPoolNetFx="Default Web Site"
    /// </code>
    public class AppPoolNetFxProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appPoolNetFx";
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
