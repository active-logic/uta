using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using static Active.Howl.Config;

namespace Unit{
public class ConfigTest : TestBase{

    [Test] public void AllowImport_get(){ var x = allowImport; }

    [Test] public void AllowExport_get(){ var x = allowExport; }

    [Test] public void AllowImport_set([Values(true, false)] ㅇ x){
        allowImport = x; o(allowImport, x);
    }

    [Test] public void AllowExport_set([Values(true, false)] ㅇ x){
        allowExport = x; o(allowExport, x);
    }

}}
