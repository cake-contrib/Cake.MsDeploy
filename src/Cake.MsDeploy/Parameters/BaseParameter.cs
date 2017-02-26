using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.MsDeploy.Parameters
{
    public abstract class BaseParameter
    {
        public void AppendCommonParameters(StringBuilder sb, string name, ParameterKind? kind, string scope, string match)
        {
            sb.AppendFormat("name=\"{0}\"", name);

            if (kind.HasValue)
                sb.AppendFormat(",kind=\"{0}\"", kind);

            if (!string.IsNullOrWhiteSpace(scope))
                sb.AppendFormat(",scope=\"{0}\"", scope);

            if (!string.IsNullOrWhiteSpace(match))
                sb.AppendFormat(",match=\"{0}\"", match);
        }
    }
}