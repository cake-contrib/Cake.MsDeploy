using System;
using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Runs a command on the destination when sync is called.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:sync -source:runCommand="net start MyService" -dest:auto
    /// </code>
    public class RunCommandProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "runCommand";
            }
        }

        /// <summary>
        /// A true or false value for the 'dontUseCommandExe' setting.
        /// </summary>
        public bool? DontUseCommandExe { get; set; }

        /// <summary>
        /// A true or false value for the 'dontUseJobObject' setting.
        /// </summary>
        public bool? DontUseJobObject { get; set; }

        /// <summary>
        /// An integer value for the 'waitAttempts' setting.
        /// </summary>
        public int? WaitAttempts { get; set; }

        /// <summary>
        /// An integer value for the 'waitInterval' setting.
        /// </summary>
        public int? WaitInterval { get; set; }

        /// <summary>
        /// A semicolon (;) separated list of return values that will be treated as a success for the command. If specified, all other return values will be treated as errors.
        /// </summary>
        public string SuccessReturnCodes { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if (DontUseCommandExe.HasValue)
                sb.AppendFormat(",dontUseCommandExe={0}", DontUseCommandExe);

            if (DontUseJobObject.HasValue)
                sb.AppendFormat(",dontUseJobObject={0}", DontUseJobObject);

            if (WaitAttempts.HasValue)
                sb.AppendFormat(",waitAttempts={0}", WaitAttempts);

            if (WaitInterval.HasValue)
                sb.AppendFormat(",waitInterval={0}", WaitInterval);

            if (!string.IsNullOrWhiteSpace(SuccessReturnCodes))
                sb.AppendFormat(",successReturnCodes=\"{0}\"", SuccessReturnCodes);
        }
    }
}
