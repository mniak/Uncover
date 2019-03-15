using System;
using Fody;
using Xunit;
using Shouldly;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 618
public class WeaverTests
{
    static readonly TestResult testResult;

    static WeaverTests()
    {
        var weavingTask = new ModuleWeaver();
        testResult = weavingTask.ExecuteTestRun("AssemblyToProcess.dll");
    }

    [Fact]
    public void Class1_ShouldHaveExcludeAttribute()
    {
        var type = GetTypeOfClass1();

        type.CustomAttributes.ShouldContain(x => x.AttributeType == typeof(ExcludeFromCodeCoverageAttribute));
    }

    [Fact]
    public void Class2_ShouldHaveExcludeAttribute()
    {
        var type = GetTypeOfClass2();

        type.CustomAttributes.ShouldContain(x => x.AttributeType == typeof(ExcludeFromCodeCoverageAttribute));
    }
    
    [Fact]
    public void Class2_ShouldHaveOnlyOneExcludeAttribute()
    {
        var type = GetTypeOfClass2();

        type.CustomAttributes.ShouldContain(x => x.AttributeType == typeof(ExcludeFromCodeCoverageAttribute), 1);
    }


    private static Type GetTypeOfClass1()
    {
        return testResult.Assembly.GetType("AssemblyToProcess.Class1");
    }

    private static Type GetTypeOfClass2()
    {
        return testResult.Assembly.GetType("AssemblyToProcess.Class2");
    }
}
