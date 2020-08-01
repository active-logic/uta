using NUnit.Framework;
using Active.Howl;

namespace Unit{
public class ConfigTest : TestBase{

    Config c;

    [SetUp] public void Setup() => c = new Config();

    [Test] public void AllowImport(){
        var x = c.allowImport;
        c.allowImport = !x;   o(c.allowImport, !x);
        c.allowImport = x;    o(c.allowImport,  x);
    }

    [Test] public void AllowExport(){
        var x = c.allowExport;
        c.allowExport = !x;   o( c.allowExport, !x);
        c.allowExport = x;    o( c.allowExport,  x);
    }

    [Test] public void IgnoreConflicts(){
        var x = c.ignoreConflicts;
        c.ignoreConflicts = !x;   o( c.ignoreConflicts, !x);
        c.ignoreConflicts = x;    o( c.ignoreConflicts,  x);
    }

}}
