namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// 32-bit COM object
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:comObject32="Example.ProgId"
    /// </code>
    public class ComObject32Provider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "comObject32";
            }
        }
    }
}
