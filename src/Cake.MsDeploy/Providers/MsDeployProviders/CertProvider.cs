namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Certificate
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:cert="MY\5F9D38B39E526C0D3375BE3492A27CF800697EAF"
    /// </code>
    public class CertProvider : MsDeployProvider
    {
        public CertProvider()
        {
            AppendQuotesToPath = true;
        }

        public override string Type
        {
            get
            {
                return "cert";
            }
        }
    }
}
