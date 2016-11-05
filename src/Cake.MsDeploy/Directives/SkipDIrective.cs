using System;
using System.Text;

namespace Cake.MsDeploy.Directives
{
    /// <summary>
    /// Directive used to exclude objects from a sync operation, or it lets you use a skip rule to exclude actions from an operation.
    /// </summary>
    public class SkipDirective : IMsDeployArgument
    {
        /// <summary>
        /// Which action to skip
        /// </summary>
        public SkipAction? SkipAction { get; set; }

        /// <summary>
        /// Regular expression that will be used to match the object name
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// Regular expression that will be used to match the absolute path of the object
        /// </summary>
        public string AbsolutePath { get; set; }

        /// <summary>
        /// XPath expression that identifies the object.
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// Regular expression that will be used to match the value of the key attribute of the object.
        /// </summary>
        public string KeyAttribute { get; set; }

        /// <summary>
        ///  Converts the SkipDirective into its commmand line argument
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
            
            sb.Append("-skip:");

            if (SkipAction.HasValue)
                sb.AppendFormat("skipAction={0}", SkipAction);

            if (!string.IsNullOrWhiteSpace(ObjectName))
            {
                if (SkipAction.HasValue)
                    sb.Append(",");

                sb.AppendFormat("objectName={0}", ObjectName);
            }

            if (!string.IsNullOrWhiteSpace(AbsolutePath))
                sb.AppendFormat(",absolutePath=\"{0}\"", AbsolutePath);

            if (!string.IsNullOrWhiteSpace(XPath))
                sb.AppendFormat(",xPath=\"{0}\"", XPath);

            if (!string.IsNullOrWhiteSpace(KeyAttribute))
                sb.AppendFormat(",keyAttribute=\"{0}\"", KeyAttribute);
        }
    }
}
