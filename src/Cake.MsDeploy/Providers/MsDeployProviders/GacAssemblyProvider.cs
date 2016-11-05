namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// GAC assembly
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:gacAssembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=x86"
    /// </code>
    public class GacAssemblyProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "gacAssembly";
            }
        }
    }
}
