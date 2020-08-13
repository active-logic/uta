using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class CLI_Test{

    CLI ι;

    [SetUp] public void Setup () => ι = new CLI();

    // Fails in .net because of path differences
    #if UNITY_EDITOR
    [Test] public void Export () => ι.Export(null, "Assets/Howl/Editor/Ng", "Sandbox/CLI");
    #endif

}}
