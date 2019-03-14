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
    private MethodReference attributeConstructor;

    public override void Execute()
    {
        attributeConstructor = ModuleDefinition.ImportReference(typeof(ExcludeFromCodeCoverageAttribute).GetConstructor(Type.EmptyTypes));

        ProcessAssemblyWideExclusionAttribute();
    }

    private void ProcessAssemblyWideExclusionAttribute()
    {
        var assemblyHasAttribute = ModuleDefinition.Assembly.CustomAttributes.HasAttribute("ExcludeAssemblyFromCodeCoverageAttribute");

        if (!assemblyHasAttribute)
            return;

        var types = ModuleDefinition.Types;
        var excludeAttribute = typeof(ExcludeFromCodeCoverageAttribute);
        foreach (var type in types)
        {
            var typeAlreadyHasAttribute = type.CustomAttributes.HasAttribute("System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute");

            if (!typeAlreadyHasAttribute)
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