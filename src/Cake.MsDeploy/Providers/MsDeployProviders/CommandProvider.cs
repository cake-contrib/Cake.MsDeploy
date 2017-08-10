using System;
using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
	/// <summary>
	/// Runs a command on the destination when preSync/postSync is called.
	/// </summary>
	/// <code>
	/// -preSync:runCommand="net stop MyService",waitInterval=60000
	/// -postSync:runCommand="net start MyService",waitInterval=60000
	/// </code>
	public class CommandProvider : RunCommandProvider
	{
		public static implicit operator CommandProvider(string command)
		{
			return new CommandProvider { Path = command };
		}

		public override void AppendCommandLineArgument(StringBuilder sb)
		{
			sb.AppendFormat("runCommand=\"{0}\"", Path);
			AdditionalSettings(sb);
		}
	}
}
