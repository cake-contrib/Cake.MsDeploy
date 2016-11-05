namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// This provider is used to sync Centralized SSL Certificates Support store settings. It does not require any path to be specified and can only be utilized on IIS 8 and later.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:certStoreSettings
    /// </code>
    public class CertStoreSettingsProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "certStoreSettings";
            }
        }
    }
}
