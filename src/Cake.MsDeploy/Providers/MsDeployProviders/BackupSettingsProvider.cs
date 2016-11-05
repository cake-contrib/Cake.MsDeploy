    using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Manages your site's backup settings
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:backupSettings="siteName"
    /// </code>
    public class BackupSettingsProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "backupSettings";
            }
        }

        /// <summary>
        /// A boolean value used to specify whether backups will occur during a sync.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Positive integer used to specify the maximum number of backups you would like to store on the server
        /// </summary>
        public int? NumberOfBackups { get; set; }

        /// <summary>
        /// Boolean value to specify if a sync to your site should continue if a backup fails
        /// </summary>
        public bool? ContinueSyncOnBackupFailure { get; set; }

        /// <summary>
        /// List of providers to add to the existing excluded provider list for a backup.
        /// </summary>
        public IEnumerable<string> AddExcludedProviders { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (Enabled.HasValue)
                sb.AppendFormat(",enabled={0}", Enabled);

            if (NumberOfBackups.HasValue)
                sb.AppendFormat(",numberOfBackups={0}", NumberOfBackups);

            if (ContinueSyncOnBackupFailure.HasValue)
                sb.AppendFormat(",continueSyncOnBackupFailure={0}", ContinueSyncOnBackupFailure);

            if (AddExcludedProviders != null && AddExcludedProviders.Any())
                sb.AppendFormat(",addExcludedProviders={0}", string.Join<string>(";", AddExcludedProviders));            
        }
    }
}
