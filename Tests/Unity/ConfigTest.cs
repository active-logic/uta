using System.IO;
using InvOp = System.InvalidOperationException;
using NUnit.Framework;
using static Active.Howl.Config;

namespace Unit{
public class ConfigTest : TestBase{

    [Test] public void AllowImport_get(){ var x = allowImport; }

    [Test] public void AllowExport_get(){ var x = allowExport; }

    [Test] public void AllowImport_set([Values(true, false)] bool x){
        allowImport = x; o(allowImport, x);
    }

    [Test] public void AllowExport_set([Values(true, false)] bool x){
        allowExport = x; o(allowExport, x);
    }

}}
