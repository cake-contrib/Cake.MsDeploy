using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Providers
{
    /// <summary>
    /// contract for an MsDeployProvider
    /// </summary>
    public interface IMsDeployProvider : IMsDeployArgument
    {
        /// <summary>
        /// Name of the MSDeploy Provider
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Determines if the Provider is a source or destination
        /// </summary>
       Direction Direction { get; set; }

        /// <summary>
        /// Path of the provider type
        /// </summary>
        string Path { get; set; }

        /// <summary>
        ///  Name of remote computer or proxy-URL
        /// </summary>
        string ComputerName { get; set; }

        /// <summary>
        ///  Name of remote computer or proxy-URL for the Web Management Service (WMSvc). Assumes that the service is listening on port 8172.
        /// </summary>
        string WebManagementService { get; set; }

        /// <summary>
        ///  Authentication scheme to use. NTLM is the default setting. If the wmsvc option is specified, then Basic is the default setting.
        /// </summary>
        AuthenticationScheme? AuthenticationType { get; set; }

        /// <summary>
        /// User name to authenticate for remote connections (required if using Basic authentication).
        /// </summary>
        string Username { get; set; }

        /// <summary>
        ///  Password of the user for remote connections (required if using Basic authentication).
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// If true, include ACLs in the operation (applies to the file system, registry, and  metabase).
        /// </summary>
        bool? IncludeAcls { get; set; }

        /// <summary>
        ///  Temporarily install the remote agent for the duration of a remote operation.
        /// </summary>
        bool? TempAgent { get; set; }

        /// <summary>
        ///  File path to a publish settings file which contains remote connection information
        /// </summary>
        string PublishSettings { get; set; }
    }
}
