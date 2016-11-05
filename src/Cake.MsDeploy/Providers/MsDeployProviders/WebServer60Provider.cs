namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// WebServer60
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:webServer60
    /// </code>
    public class WebServer60Provider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "webServer60";
            }
        }
    }
}
