using System;
using System.Text;

namespace Cake.MsDeploy.Parameters
{
    /// <summary>
    /// Enables you to specify, at synchronization time, a value for parameter that you declared by using <see cref="DeclareParameter"/>
    /// Also see the documentation at https://technet.microsoft.com/en-us/library/dd569084(v=ws.10).aspx 
    /// </summary>
    public class SetParameter : IParameter
    {
        /// <summary>
        /// Name of the declared parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  specifies the parameter kind
        /// </summary>
        public ParameterKind? Kind { get; set; }

        /// <summary>
        /// The scope of the specified parameter kind
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Specifies an item to be matched
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// Specifies the value for a parameter
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// An optional user-supplied string that describes the purpose of the parameter
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Converts the SetParameter into its commmand line argument
        /// </summary>
        public string ToCommandLineArgument()
        {
            var sb = new StringBuilder();
            AppendCommandLineArgument(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the object into its MSDeploy command line equivalent and Appends it to the stringbuilder
        /// </summary>
        /// <param name="sb">StringBuilder to apply command line to.</param>
        public void AppendCommandLineArgument(StringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            if (string.IsNullOrWhiteSpace(Name))
                throw new NullReferenceException("Name is required when using the SetParameter option.");

            sb.Append("-setParam:");

            sb.AppendFormat("name=\"{0}\"", Name);

            if (Kind.HasValue)
                sb.AppendFormat(",kind=\"{0}\"", Kind);

            if (!string.IsNullOrWhiteSpace(Scope))
                sb.AppendFormat(",scope=\"{0}\"", Scope);

            if (!string.IsNullOrWhiteSpace(Match))
                sb.AppendFormat(",match=\"{0}\"", Match);

            if (!string.IsNullOrWhiteSpace(Value))
                sb.AppendFormat(",value=\"{0}\"", Value);

            if (!string.IsNullOrWhiteSpace(Description))
                sb.AppendFormat(",description=\"{0}\"", Description);
        }
    }
}
