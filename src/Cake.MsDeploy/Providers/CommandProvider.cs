using System;
using System.Text;

namespace Cake.MsDeploy.Providers
{
	/// <summary>
	/// Runs a command on the destination when preSync/postSync is called.
	/// </summary>
	/// <code>
	/// -preSync:runCommand="net stop MyService",waitInterval=60000
	/// -postSync:runCommand="net start MyService",waitInterval=60000
	/// </code>
	public class CommandProvider
	{
		public static implicit operator CommandProvider(string command)
		{
			return new CommandProvider { Command = command };
		}

		/// <summary>
		///Command value for the 'runCommand' setting.
		/// </summary>
		public string Command { get; set; }

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

		/// <summary>
		/// Converts the Provider into its commmand line argument
		/// </summary>
		public virtual string ToCommandLineArgument()
		{
			var sb = new StringBuilder();
			AppendCommandLineArgument(sb);
			return sb.ToString();
		}

		public void AppendCommandLineArgument(StringBuilder sb)
		{
			sb.AppendFormat("runCommand=\"{0}\"", Command);
			AdditionalSettings(sb);
		}

		protected void AdditionalSettings(StringBuilder sb)
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
