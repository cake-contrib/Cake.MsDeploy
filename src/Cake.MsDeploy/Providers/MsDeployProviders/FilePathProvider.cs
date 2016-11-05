using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// filePath
    /// </summary>
    /// <code>
    ///  msdeploy.exe -verb:dump -source:filePath="c:\inetpub\wwwroot\default.htm"
    /// </code>
    public class FilePathProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "filePath";
            }
        }

        /// <summary>
        /// A semicolon (;) separated list of file system error codes that should be ignored.
        /// </summary>
        public string IgnoreErrors { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(IgnoreErrors))
                sb.AppendFormat(",ignoreErrors=\"{0}\"", IgnoreErrors);
        }
    }
}
