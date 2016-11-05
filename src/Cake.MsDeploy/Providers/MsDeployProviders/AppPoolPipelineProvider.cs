using System.Text;

namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// The appPoolPipeline provider displays or sets the managed pipeline mode of the specified IIS application pool.
    /// </summary>
    /// <code>
    /// msdeploy.exe -verb:dump -source:appPoolPipeline="Default Web Site"
    /// </code>
    public class AppPoolPipelineProvider : MsDeployProvider
    {
        public override string Type
        {
            get
            {
                return "appPoolPipeline";
            }
        }

        /// <summary>
        /// Set managedPipelineMode to Classic or Integrated in order to validate if the destination application pool matches.The value will not be set, it will only be compared.
        /// </summary>
        public AppPoolPipelineMode? PipelineMode { get; set; }

        protected override void AdditionalSettings(StringBuilder sb)
        {
            if(PipelineMode.HasValue)
                sb.AppendFormat(",pipelineMode={0}", PipelineMode);
        }
    }
}
