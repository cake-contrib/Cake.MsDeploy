namespace Cake.MsDeploy.Parameters
{
    /// <summary>
    /// Contract for a parameter
    /// </summary>
    public interface IParameter : IMsDeployArgument
    {
        /// <summary>
        /// Name of the declared parameter
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///  specifies the parameter kind
        /// </summary>
        ParameterKind? Kind { get; set; }

        /// <summary>
        /// The scope of the specified parameter kind
        /// </summary>
        string Scope { get; set; }

        /// <summary>
        /// Specifies an item to be matched
        /// </summary>
        string Match { get; set; }
        
        /// <summary>
        /// An optional user-supplied string that describes the purpose of the parameter
        /// </summary>
        string Description { get; set; }
        
    }
}
