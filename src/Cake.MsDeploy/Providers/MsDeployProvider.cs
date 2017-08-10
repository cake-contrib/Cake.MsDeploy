using System;
using System.Text;

namespace Cake.MsDeploy.Providers
{
    /// <summary>
    /// Base class for a MSDeploy Provider Process specific source or destination information for an MsDeploy provider. 
    /// <a href="https://technet.microsoft.com/en-us/library/dd569040(v=ws.10).aspx">Web Deploy Providers</a>
    /// </summary>
    public abstract class MsDeployProvider : IMsDeployProvider
    {
        /// <summary>
        /// Name of the MSDeploy Provider
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// Determines if the Path argument is required for the MsDeployProvider
        /// </summary>
        protected bool RequirePath { get; set; } = true;

        /// <summary>
        /// Determines if the Provider is a source or destination
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Path of the provider type
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Determines if the Path is surrounded in "quotes"
        /// </summary>
        public bool AppendQuotesToPath { get; set; } = true;

        /// <summary>
        ///  Name of remote computer or proxy-URL
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        ///  Name of remote computer or proxy-URL for the Web Management Service (WMSvc). Assumes that the service is listening on port 8172.
        /// </summary>
        public string WebManagementService { get; set; }

        /// <summary>
        ///  Authentication scheme to use. NTLM is the default setting. If the wmsvc option is specified, then Basic is the default setting.
        /// </summary>
        public AuthenticationScheme? AuthenticationType { get; set; }

        /// <summary>
        /// User name to authenticate for remote connections (required if using Basic authentication).
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///  Password of the user for remote connections (required if using Basic authentication).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// If true, include ACLs in the operation (applies to the file system, registry, and  metabase).
        /// </summary>
        public bool? IncludeAcls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? TempAgent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PublishSettings { get; set; }

        /// <summary>
        /// Converts the MSDeploy Provider into its commmand line argument
        /// </summary>
        public virtual string ToCommandLineArgument()
        {
            var sb = new StringBuilder();
            AppendCommandLineArgument(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the object into its MSDeploy command line equivalent and Appends it to the stringbuilder
        /// </summary>
        /// <param name="sb">StringBuilder to apply command line to.</param>
        public virtual void AppendCommandLineArgument(StringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            sb.AppendFormat("-{0}:", Direction);

            //Path
            if (RequirePath)
            {
                sb.AppendFormat("{0}=", Type);

                if (!string.IsNullOrWhiteSpace(Path))
                {
                    if (AppendQuotesToPath)
                        sb.Append('\"');

                    sb.Append(Path);

                    if (AppendQuotesToPath)
                        sb.Append('\"');
                }
            }
            else
                sb.Append(Type);

            if (!string.IsNullOrWhiteSpace(ComputerName))
                sb.AppendFormat(",computerName=\"{0}\"", ComputerName);

            if (!string.IsNullOrWhiteSpace(WebManagementService))
                sb.AppendFormat(",wmsvc=\"{0}\"", WebManagementService);

            if (AuthenticationType.HasValue)
                sb.AppendFormat(",authtype={0}", AuthenticationType);

            if (!string.IsNullOrWhiteSpace(Username))
                sb.AppendFormat(",userName={0}", Username);

            if (!string.IsNullOrWhiteSpace(Password))
                sb.AppendFormat(",password={0}", Password);

            if (IncludeAcls.HasValue)
                sb.AppendFormat(",includeAcls={0}", IncludeAcls.Value.ToString().ToLower());

            if (TempAgent.HasValue)
                sb.AppendFormat(",tempAgent={0}", TempAgent.Value.ToString().ToLower());

            if (!string.IsNullOrWhiteSpace(PublishSettings))
                sb.AppendFormat(",publishSettings=\"{0}\"", PublishSettings);

            AdditionalSettings(sb);
        }

        /// <summary>
        /// Applies additional settings on a per provider basis
        /// </summary>
        protected virtual void AdditionalSettings(StringBuilder sb)
        { }
    
    }
}
