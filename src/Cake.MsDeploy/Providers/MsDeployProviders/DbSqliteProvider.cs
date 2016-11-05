using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    public class DbSqliteProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "dbSqlite";
            }
        }

        /// <summary>
        /// A connection string used to create the database on the destination if the database specified in the
        /// </summary>
        public string CreateDBConnectionString { get; set; }

        /// <summary>
        /// A true or false value for the 'includeData' setting.
        /// </summary>
        public bool? IncludeData { get; set; }

        /// <summary>
        /// A true or false value for the 'transacted' setting.
        /// </summary>
        public bool? Transacted { get; set; }

        /// <summary>
        /// A string that is used to separate database commands in the script.
        /// </summary>
        public string CommandDelimiter { get; set; }

        /// <summary>
        /// A true or false value for the 'removeCommandDelimiter' setting.
        /// </summary>
        public bool? RemoveCommandDelimiter { get; set; }

        /// <summary>
        /// An integer value for the 'waitAttempts' setting.
        /// </summary>
        public int? WaitAttempts { get; set; }

        /// <summary>
        /// An integer value for the 'waitInterval' setting.
        /// </summary>
        public int? WaitInterval { get; set; }

        /// <summary>
        /// An integer value for the 'commandTimeout' setting.
        /// </summary>
        public int? CommandTimeout { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(CreateDBConnectionString))
                sb.AppendFormat(",createDBConnectionString=\"{0}\"", CreateDBConnectionString);

            if (IncludeData.HasValue)
                sb.AppendFormat(",includeData={0}", IncludeData);

            if (Transacted.HasValue)
                sb.AppendFormat(",transacted={0}", Transacted);

            if (!string.IsNullOrWhiteSpace(CommandDelimiter))
                sb.AppendFormat(",commandDelimiter=\"{0}\"", CommandDelimiter);

            if (RemoveCommandDelimiter.HasValue)
                sb.AppendFormat(",removeCommandDelimiter={0}", RemoveCommandDelimiter);

            if (WaitAttempts.HasValue)
                sb.AppendFormat(",waitAttempts={0}", WaitAttempts);

            if (WaitInterval.HasValue)
                sb.AppendFormat(",waitInterval={0}", WaitInterval);

            if (CommandTimeout.HasValue)
                sb.AppendFormat(",commandTimeout={0}", CommandTimeout);
        }
    }
}
