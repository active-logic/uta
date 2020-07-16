using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class MapFunctionalTest : TestBase{

    [Test] public void ExcludeStringLiterals(){
        var x = Map.@default;
        o("if this is an \"if\" statement" / x,
          "⤴ this is an \"if\" statement");
    }

    [Test] public void ExcludeDefs(){
        var x = Map.@default;
        o("if bool\n#if UFO" / x, "⤴ ㅇ\n#if UFO");
    }

    [Test] public void ExcludeCStyleComments(){
        var x = Map.@default;
        o("if bool\n/*if \nUFO*/" / x, "⤴ ㅇ\n/*if \nUFO*/");
    }

    [Test] public void ExcludeCppStyleComments(){
        var x = Map.@default;
        o("if bool\n//if UFO" / x, "⤴ ㅇ\n//if UFO");
    }

}
