using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Metabase key
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:metaKey="LM/W3SVC/1/ROOT"
    /// </code>
    public class MetaKeyProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "metaKey";
            }
        }

        /// <summary>
        /// A true or false value for the 'MetadataGetInherited' setting.
        /// </summary>
        public bool? MetadataGetInherited { get; set; }

        /// <summary>
        /// A true or false value for the 'UseRealAbo' setting.
        /// </summary>
        public bool? UseRealAbo { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (MetadataGetInherited.HasValue)
                sb.AppendFormat(",metadataGetInherited={0}", MetadataGetInherited);

            if (UseRealAbo.HasValue)
                sb.AppendFormat(",useRealAbo={0}", UseRealAbo);
        }
    }
}
