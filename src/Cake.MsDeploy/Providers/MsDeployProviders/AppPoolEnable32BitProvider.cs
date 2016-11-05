using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Enable 32-bit application pool on IIS7.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:appPoolEnable32Bit="Default Web Site"
    /// </code>
    public class AppPoolEnable32BitProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appPoolEnable32Bit";
            }
        }

        /// <summary>
        /// true or false value for the 'Enable32Bit' setting.
        /// </summary>
        public bool? Enable32Bit { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (Enable32Bit.HasValue)
                sb.AppendFormat(",enable32Bit={0}", Enable32Bit);
        }
    }
}
