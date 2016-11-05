namespace Cake.MsDeploy.Providers.MsDeployProviders
{
    /// <summary>
    /// Action to take when using the the "recycleApp" provider
    /// </summary>
    public enum RecycleMode
    {
        RecycleAppPool = 0,
        StartAppPool,
        StopAppPool,
        UnloadAppDomain
    }
}
