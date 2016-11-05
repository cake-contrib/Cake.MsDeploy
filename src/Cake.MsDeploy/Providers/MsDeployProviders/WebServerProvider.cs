namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Full IIS 7 Web server
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:webServer
    /// </code>
    public class WebServerProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "webServer";
            }
        }
    }
}
