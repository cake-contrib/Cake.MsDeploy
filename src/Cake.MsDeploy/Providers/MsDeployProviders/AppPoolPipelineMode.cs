namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Set managedPipelineMode to Classic or Integrated in order to validate if the destination application pool matches.The value will not be set, it will only be compared.
    /// </summary>
    public enum AppPoolPipelineMode
    {
        Integrated = 0,
        Classic = 1
    }
}
