using System.Text;

namespace Cake.MsDeploy
{
    /// <summary>
    /// Marks the object as able to be converted into an MSDeploy command line argument
    /// </summary>
    public interface IMsDeployArgument
    {
        /// <summary>
        /// Converts the object into its MSDeploy command line equivalent
        /// </summary>
        string ToCommandLineArgument();

        /// <summary>
        /// Converts the object into its MSDeploy command line equivalent and Appends it to the stringbuilder
        /// </summary>
        /// <param name="sb">StringBuilder to apply command line to.</param>
        void AppendCommandLineArgument(StringBuilder sb);
    }
}
