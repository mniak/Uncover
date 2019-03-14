using System;

/// <summary>
/// Excludes the assembly from the code coverage.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class ExcludeAssemblyFromCodeCoverageAttribute : Attribute
{
    
}