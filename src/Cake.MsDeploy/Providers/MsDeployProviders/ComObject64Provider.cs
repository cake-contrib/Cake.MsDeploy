namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// 64-bit COM object
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:comObject64="Example.ProgId"
    /// </code>
    public class ComObject64Provider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "comObject64";
            }
        }
    }
}
