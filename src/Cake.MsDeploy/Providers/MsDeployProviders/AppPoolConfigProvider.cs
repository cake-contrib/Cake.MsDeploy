namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// IIS 7 Application Pool
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:appPoolConfig="DefaultAppPool"
    /// </code>
    public class AppPoolConfigProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appPoolConfig";
            }
        }
    }
}
