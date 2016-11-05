namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// IIS 7 configuration schema
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:appHostSchema
    /// </code>
    public class AppHostSchemaProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appHostSchema";
            }
        }
    }
}
