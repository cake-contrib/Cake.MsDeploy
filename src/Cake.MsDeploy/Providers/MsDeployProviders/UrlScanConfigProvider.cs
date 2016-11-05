namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    ///  UrlScan.ini settings or requestFiltering section configuration
    /// </summary>
    /// <code>
    ///    msdeploy.exe -verb:dump -source:urlScanConfig="ini"
    ///    msdeploy.exe -verb:dump -source:urlScanConfig="apphost"
    /// </code>
    public class UrlScanConfigProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "urlScanConfig";
            }
        }
    }
}
