using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Mono.Cecil.Cil;
using Fody;
using System.Diagnostics.CodeAnalysis;
using System;

public class ModuleWeaver : BaseModuleWeaver
{
    private TypeReference attributeType;
    private MethodReference attributeConstructor;

    public override void Execute()
    {
        attributeType = ModuleDefinition.ImportReference(typeof(ExcludeFromCodeCoverageAttribute));
        attributeConstructor = ModuleDefinition.ImportReference(typeof(ExcludeFromCodeCoverageAttribute).GetConstructor(Type.EmptyTypes));

        var types = ModuleDefinition.Types;
        var excludeAttribute = typeof(ExcludeFromCodeCoverageAttribute);
        foreach (var type in types)
        {
            var hasAttr = type.CustomAttributes
                .Select(x => x.AttributeType)
                .Where(x => x.FullName == excludeAttribute.FullName)
                .Where(x => !x.ContainsGenericParameter)
                .Any();

            if (!hasAttr)
                AddAttribute(type);
        }
    }

    private void AddAttribute(TypeDefinition type)
    {
        type.CustomAttributes.Add(new CustomAttribute(attributeConstructor));
    }

    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "netstandard";
        yield return "mscorlib";
    }

    public override bool ShouldCleanReference => true;
}