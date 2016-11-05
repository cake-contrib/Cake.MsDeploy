using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Providers
{
    /// <summary>
    /// Determines if the Provider is a source or destination
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// The source object for the operation (required).
        /// </summary>
        source,
        /// <summary>
        /// The destination object for the operation.
        /// </summary>
        dest
    }
}
