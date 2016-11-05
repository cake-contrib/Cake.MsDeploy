namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Registry key
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:regKey="HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework"
    /// </code>
    public class RegKeyProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "regKey";
            }
        }
    }
}
