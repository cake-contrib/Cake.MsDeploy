using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Custom manifest file
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:manifest="c:\manifest.xml"
    /// </code>
    public class ManifestProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "manifest";
            }
        }


        /// <summary>
        /// A true or false value for the 'skipInvalid' setting.
        /// </summary>
        public bool? SkipInvalid { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (SkipInvalid.HasValue)
                sb.AppendFormat(",skipInvalid={0}", SkipInvalid);
        }
    }
}