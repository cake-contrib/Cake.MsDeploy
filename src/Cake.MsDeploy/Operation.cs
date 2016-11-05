namespace Cake.MsDeploy
{
    /// <summary>
    /// MsDeploy operations
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// Synchronizes data between a source and a destination.
        /// </summary>
        Sync,
        /// <summary>
        /// Returns information about a source object
        /// </summary>
        Dump,
        /// <summary>
        /// Deletes the object(s) specified by the destination argument.
        /// </summary>
        Delete
    }
}
