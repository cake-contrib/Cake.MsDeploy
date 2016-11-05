namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Registry value
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:regValue="HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\DbgJITDebugLaunchSetting"
    /// </code>
    public class RegValueProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "regValue";
            }
        }
    }
}
