namespace Cake.MsDeploy.Directives
{
    /// <summary>
    /// Including this setting causes the skip to be handled as a skip rule, thus avoiding the actions from being performed on the objects identified by the other settings.
    /// </summary>
    public enum SkipAction 
    {
        /// <summary>
        /// update Skip Action
        /// </summary>
        Update,
        /// <summary>
        /// Delete Skip Action
        /// </summary>
        Delete,
        /// <summary>
        /// Add Child Skip Action
        /// </summary>
        AddChild
    }
}
