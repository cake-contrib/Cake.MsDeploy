using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Directory
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:dirPath="c:\inetpub\wwwroot"
    /// </code>
    public class DirPathProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "dirPath";
            }
        }

        /// <summary>
        /// A semicolon (;) separated list of file system error codes that should be ignored.
        /// </summary>
        public string IgnoreErrors { get; set; }

        /// <summary>
        /// A long value for the 'firstChangeUSN' setting.
        /// </summary>
        public long? FirstChangeUSN { get; set; }

        /// <summary>
        /// A true or false value for the 'incremental' setting.
        /// </summary>
        public bool? Incremental { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(IgnoreErrors))
                sb.AppendFormat(",ignoreErrors=\"{0}\"", IgnoreErrors);

            if (FirstChangeUSN.HasValue)
                sb.AppendFormat(",firstChangeUSN={0}", FirstChangeUSN);

            if (Incremental.HasValue)
                sb.AppendFormat(",incremental={0}", Incremental);
        }
    }
}
