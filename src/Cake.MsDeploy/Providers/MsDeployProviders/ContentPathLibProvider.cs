using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Used to deploy ASP.Net libraries that live in the 'approot' folder, which is a sibling to the content root folder.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:contentPathLib="c:\site\wwwroot"
    /// </code>
    public class ContentPathLibProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "contentPathLib";
            }
        }

        /// <summary>
        /// The ContentPathLib provider does not compare timestamps of files that live under the approot\packages folder.To force Web Deploy to compare timestamps, set this setting to 'true'.
        /// </summary>
        public bool? SyncPackageTimeStamps { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (SyncPackageTimeStamps.HasValue)
                sb.AppendFormat(",syncPackageTimeStamps={0}", SyncPackageTimeStamps);
        }
    }
}
