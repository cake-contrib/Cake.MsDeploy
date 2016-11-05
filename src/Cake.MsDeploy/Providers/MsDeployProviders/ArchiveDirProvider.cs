using System;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Archive directory
    /// </summary>
    /// <code>
    ///  msdeploy.exe -verb:dump -source:archiveDir="c:\myArchiveDir"
    /// </code>
    public class ArchiveDirProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "archiveDir";
            }
        }
    }
}
