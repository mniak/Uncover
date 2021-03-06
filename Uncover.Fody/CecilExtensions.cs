﻿using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

public static class CecilExtensions
{
    public static CustomAttribute FindAttribute(this IEnumerable<CustomAttribute> attributes, string attributeName)
    {
        return attributes.SingleOrDefault(x => x.AttributeType.FullName == attributeName);
    }
    public static bool HasAttribute(this IEnumerable<CustomAttribute> attributes, string attributeName)
    {
        return attributes.FindAttribute(attributeName) != null;
    }
}