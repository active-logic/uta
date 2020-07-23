using System.IO;
using UnityEngine;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

namespace Functional{
public class MapFu : TestBase{

    [Test] public void MapOrder(){
        var x = Map.@default;
        o(x["void"] > x["public void"]);
        o(x["public"] > x["public void"]);
        o(x["public"] > x["public static"]);
        o(x["public void"] > x["public static"]);
    }

    [Test] public void Integrity(){
        o(Map.@default.integer, true);
    }

    [Test] public void kLinesBug(){
        var x = Map.@default;
        ㄹ π = "Assets/Howl/Tests/Data/Actor.howl";
        ㄹ ㅂ = File.ReadAllText(π); ᆞ n = ㅂ.LineCount();
        ㄹ ㄸ = ㅂ * x;               ᆞ n1 = ㄸ.LineCount();
        o(n, n1);
    }

    [Test] public void RemoveRedundantUsingStatement(){
        var x = Map.@default;
        o("♖ ㅅ = System.Single;\nnoop\n" * x, "noop\n");
    }

    [Test] public void Consolidate(){
        var x = Map.@default;
        o("⤴this is it" * x, "if this is it");
    }

    [Test] public void Consolidate_BeforeSoftSymbol(){
        var x = Map.@default;
        o("⤴⤴ ifs" * x, "if if ifs");
    }

    [Test] public void Consolidate_NoSpaceBeforeOps(){
        var x = Map.@default;
        o("⤴+ is it" * x, "if+ is it");
    }

    [Test] public void Consolidate_NoDoubleSpace(){
        var x = Map.@default;
        o("⤴ this is it" * x, "if this is it");
    }

    [Test] public void ExcludeStringLiterals(){
        var x = Map.@default;
        o("if this is an \"if\" statement" / x,
          "⤴ ⦿ is an \"if\" statement");
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

}}
