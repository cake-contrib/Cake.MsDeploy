using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// .NET 64-bit root Web configuration
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:rootWebConfig64="Default Web Site"
    /// </code>
    public class RootWebConfig64Provider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "rootWebConfig64";
            }
        }

        /// <summary>
        /// Provider setting used to specify which .NET framework version to use with given provider.
        /// </summary>
        public string NetFxVersion { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(NetFxVersion))
                sb.AppendFormat(",netFxVersion=\"{0}\"", NetFxVersion);
        }
    }
}
