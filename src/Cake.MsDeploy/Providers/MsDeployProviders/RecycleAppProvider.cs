using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Recycles, starts, or stops an application's app pool, or unloads an application's app domains on IIS 7.
    /// </summary>
    /// <code>
    ///     msdeploy.exe -verb:sync -source:recycleApp -dest:recycleApp="Default Web Site/myapp",recycleMode="StopAppPool"
    ///     msdeploy.exe -verb:sync -source:recycleApp="Default Web Site/myapp" -dest:auto
    /// </code>
    public class RecycleAppProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "recycleApp";
            }
        }

        /// <summary>
        /// One of 4 values to control what action is taken on the application pool: RecycleAppPool, StartAppPool,  StopAppPool, or UnloadAppDomain.  The default is RecycleAppPool.
        /// </summary>
        public RecycleMode? RecycleMode { get; set; }

        /// <summary>
        /// Amount of time, in milliseconds, to wait for an application pool to recycle, start or stop.  To return 
        /// immediately after requesting the operation (without waiting for completion), specify zero.  To use the 
        /// application pool's startupTimeLimit and shutdownTimeLimit (or the sum of their values in the case of a 
        /// recycle), specify -1.  The default value is -1.
        /// </summary>
        public int? Timeout { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (RecycleMode.HasValue)
                sb.AppendFormat(",recycleMode={0}", RecycleMode);

            if (Timeout.HasValue)
                sb.AppendFormat(",timeout={0}", Timeout);
        }
    }
}
