using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// .NET 32-bit machine configuration
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:machineConfig32="Default Web Site"
    /// </code>
    public class MachineConfig32Provider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "machineConfig32";
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
