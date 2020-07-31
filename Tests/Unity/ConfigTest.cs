using NUnit.Framework;
using static Active.Howl.Config;

namespace Unit{
public class ConfigTest : TestBase{

    [Test] public void AllowImport(){
        var x = allowImport;
        allowImport = !x;   o(allowImport, !x);
        allowImport = x;    o(allowImport,  x);
    }

    [Test] public void AllowExport(){
        var x = allowExport;
        allowExport = !x;   o(allowExport, !x);
        allowExport = x;    o(allowExport,  x);
    }

    [Test] public void IgnoreConflicts(){
        var x = ignoreConflicts;
        ignoreConflicts = !x;   o(ignoreConflicts, !x);
        ignoreConflicts = x;    o(ignoreConflicts,  x);
    }

}}
