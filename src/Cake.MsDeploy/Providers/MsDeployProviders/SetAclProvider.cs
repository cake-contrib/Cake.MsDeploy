using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Grant permissions
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:setAcl="Default Web Site/My Application"
    /// </code>
    public class SetAclProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "setAcl";
            }
        }

        /// <summary>
        /// The name of the user account that is to be granted access. If empty, the Application Pool Identity is used
        /// </summary>
        public string SetAclUser { get; set; }

        /// <summary>
        /// The file system rights to be granted to the user (for example, FullControl, or ReadAndExecute, or Read). If empty, Read is used.
        /// </summary>
        public string SetAclAccess { get; set; }

        /// <summary>
        /// The file system entity being referenced (Directory or File). If empty, Directory is used.
        /// </summary>
        public SetAclResourceType? SetAclResourceType { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(SetAclUser))
                sb.AppendFormat(",setAclUser=\"{0}\"", SetAclUser);

            if (!string.IsNullOrWhiteSpace(SetAclAccess))
                sb.AppendFormat(",setAclAccess=\"{0}\"", SetAclAccess);

            if (SetAclResourceType.HasValue)
                sb.AppendFormat(",setAclResourceType={0}", SetAclResourceType);

        }
    }
}
