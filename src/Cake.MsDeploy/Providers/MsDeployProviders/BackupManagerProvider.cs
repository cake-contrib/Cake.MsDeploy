using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Allows you to create, list, restore, and delete backups.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:backupManager="default web site/msdeploy_2011_01_01_01_10_11.zip"
    /// </code>
    public class BackupManagerProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "backupManager";
            }
        }

        /// <summary>
        /// Used to specify a database connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Set useLatest to true to restore the latest available backup
        /// </summary>
        public bool? UseLatest { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
                sb.AppendFormat(",connectionString=\"{0}\"", ConnectionString);

            if (UseLatest.HasValue)
                sb.AppendFormat(",useLatest={0}", UseLatest);
        }
    }
}
