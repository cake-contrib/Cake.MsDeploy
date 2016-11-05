using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Deploy SQL database
    /// </summary>
    /// <code>
    ///   msdeploy.exe -verb:dump -source:dbFullSql="Data Source=.;Integrated Security=SSPI;Initial Catalog=Northwind"
    /// </code>
    public class DbFullSqlProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "dbFullSql";
            }
        }

        /// <summary>
        /// A true or false value for the 'dropDestinationDatabase' setting.
        /// </summary>
        public bool? DropDestinationDatabase { get; set; }

        /// <summary>
        /// A true or false value for the 'forceScriptDatabase' setting.
        /// </summary>
        public bool? ForceScriptDatabase { get; set; }

        /// <summary>
        /// A true or false value for the 'scriptDropsFirst' setting.
        /// </summary>
        public bool? ScriptDropsFirst { get; set; }

        /// <summary>
        /// A true or false value for the 'transacted' setting.
        /// </summary>
        public bool? Transacted { get; set; }

        /// <summary>
        /// A true or false value for the 'sqlCe' setting.
        /// </summary>
        public bool? SqlCe { get; set; }

        /// <summary>
        /// A true or false value for the 'skipSqlCmdParsing' setting.
        /// </summary>
        public bool? SkipSqlCmdParsing { get; set; }

        /// <summary>
        /// A semi-colon delimited list of SQL objects that you want to script from the database.
        /// </summary>
        public string ObjectList { get; set; }

        /// <summary>
        /// A connection string used to create the database on the destination if the database specified in the
        /// </summary>
        public string CreateDBConnectionString { get; set; }

        /// <summary>
        /// A string that is used to separate database commands in the script.
        /// </summary>
        public string CommandDelimiter { get; set; }

        /// <summary>
        /// A true or false value for the 'removeCommandDelimiter' setting.
        /// </summary>
        public bool? RemoveCommandDelimiter { get; set; }

        /// <summary>
        /// A true or false value for the 'storeConnectionStringPassword' setting.
        /// </summary>
        public bool? StoreConnectionStringPassword { get; set; }

        /// <summary>
        /// An integer value for the 'commandTimeout' setting.
        /// </summary>
        public int? CommandTimeout { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (DropDestinationDatabase.HasValue)
                sb.AppendFormat(",dropDestinationDatabase={0}", DropDestinationDatabase);

            if (ForceScriptDatabase.HasValue)
                sb.AppendFormat(",forceScriptDatabase={0}", ForceScriptDatabase);

            if (ScriptDropsFirst.HasValue)
                sb.AppendFormat(",scriptDropsFirst={0}", ScriptDropsFirst);

            if (Transacted.HasValue)
                sb.AppendFormat(",transacted={0}", Transacted);

            if (SqlCe.HasValue)
                sb.AppendFormat(",sqlCe={0}", SqlCe);

            if (SkipSqlCmdParsing.HasValue)
                sb.AppendFormat(",skipSqlCmdParsing={0}", SkipSqlCmdParsing);

            if (!string.IsNullOrWhiteSpace(ObjectList))
                sb.AppendFormat(",objectList=\"{0}\"", ObjectList);

            if (!string.IsNullOrWhiteSpace(CreateDBConnectionString))
                sb.AppendFormat(",createDBConnectionString=\"{0}\"", CreateDBConnectionString);

            if (!string.IsNullOrWhiteSpace(CommandDelimiter))
                sb.AppendFormat(",commandDelimiter=\"{0}\"", CommandDelimiter);

            if (RemoveCommandDelimiter.HasValue)
                sb.AppendFormat(",removeCommandDelimiter={0}", RemoveCommandDelimiter);

            if (StoreConnectionStringPassword.HasValue)
                sb.AppendFormat(",storeConnectionStringPassword={0}", StoreConnectionStringPassword);

            if (CommandTimeout.HasValue)
                sb.AppendFormat(",commandTimeout={0}", CommandTimeout);
        }
    }
}
