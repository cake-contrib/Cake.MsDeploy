namespace Cake.MsDeploy.Parameters
{
    /// <summary>
    /// Specifies the parameter kind. 
    /// </summary>
    public enum ParameterKind
    {
        /// <summary>
        /// Used in <see cref="DeclareParameter"/>, Makes any specified attribute into a parameter
        /// Used in <see cref="SetParameter"/>, Changes value of object attribute
        /// </summary>
        DeploymentObjectAttribute,
        /// <summary>
        /// Used in <see cref="DeclareParameter"/>, assigns a parameter to the source
        /// Used in <see cref="SetParameter"/>,  new value can used to assign to the source
        /// </summary>
        DestinationBinding,
        /// <summary>
        /// Used in <see cref="DeclareParameter"/>, physical path of a source virtual directory
        /// Used in <see cref="SetParameter"/>, sets physical path
        /// </summary>
        DestinationVirtualDirectory,
        /// <summary>
        /// Parameterize a provider path so that it can be changed during a synchronization operation
        /// </summary>
        ProviderPath,
        /// <summary>
        /// Specifies a string or strings to be replaced in a text file.
        /// </summary>
        TextFile,
        /// <summary>
        /// Replaces content in any XML file. 
        /// </summary>
        XmlFile
    }
}