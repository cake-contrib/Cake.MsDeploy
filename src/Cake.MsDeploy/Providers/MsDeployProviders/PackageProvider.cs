namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// A .zip file package
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:package="c:\package.zip"
    /// </code>
    public class PackageProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "package";
            }
        }
    }
}
