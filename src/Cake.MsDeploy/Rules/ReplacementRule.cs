using System;
using System.Text;

namespace Cake.MsDeploy.Rules
{
    /// <summary>
    ///  Items to replace during a synchronization operation. 
    /// </summary>
    public class ReplacementRule : IMsDeployArgument
    {
        /// <summary>
        /// Returns the deployment objects that have names that match the regular expression
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Returns only the objects that have one or more attribute names that match the regular expression
        /// </summary>
        public string ScopeAttributeName { get; set; }

        /// <summary>
        /// Returns only objects that have an attribute with a value that matches the regular expression
        /// </summary>
        public string ScopeAttributeValue { get; set; }

        /// <summary>
        /// The attribute name or names where the replace rule will apply. I
        /// </summary>
        public string TargetAttributeName { get; set; }

        /// <summary>
        /// Optional text to find that matches the regular expression
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// Replaces the values specified with this value
        /// </summary>
        public string Value { get; set; }

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

            if (string.IsNullOrWhiteSpace(ObjectName))
                throw new NullReferenceException("ObjectName is required for a replacement rule.");

            sb.Append("-replace:");
            sb.AppendFormat("objectName={0}", ObjectName);

            if (!string.IsNullOrWhiteSpace(ScopeAttributeName))
                sb.AppendFormat(",scopeAttributeName=\"{0}\"", ScopeAttributeName);

            if (!string.IsNullOrWhiteSpace(ScopeAttributeValue))
                sb.AppendFormat(",scopeAttributeValue=\"{0}\"", ScopeAttributeValue);

            if (!string.IsNullOrWhiteSpace(TargetAttributeName))
                sb.AppendFormat(",targetAttributeName=\"{0}\"", TargetAttributeName);

            if (!string.IsNullOrWhiteSpace(Match))
                sb.AppendFormat(",match=\"{0}\"", Match);

            if (!string.IsNullOrWhiteSpace(Value))
                sb.AppendFormat(",replace=\"{0}\"", Value);
        }
    }
}
