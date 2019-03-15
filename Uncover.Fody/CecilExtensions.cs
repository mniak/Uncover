using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

public static class CecilExtensions
{
    public static bool HasAttribute(this IEnumerable<CustomAttribute> attributes, string attributeName)
    {
        return attributes
            .Select(x => x.AttributeType)
            .Where(x => x.FullName == attributeName)
            .Any();
    }
}