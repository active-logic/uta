using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;

public class MapTest : TestBase{

    [Test] public void FromRepArray(){
        Map x = new Rep[]{ ("a", "b"), ("c", "d") };
        o(x.rules.Length, 2);
        o(x.remove.Length, 2);
        o(x.remove[0].hint, "using a");
    }

    [Test] public void Apply(){
        var x = Map.@default;
        o("心 ┈ Act()" * x, "public void Act()");
    }

    [Test] public void Revert(){
        var x = Map.@default;
        o("public void Act()" / x, "心 ┈ Act()");
    }

    [Test] public void Revert_WithBridgedToken(){
        var x = Map.@default;
        o("public static void Act()" / x, "切 ┈ Act()");
    }

    [Test] public void RemoveLegacyUsing(){
        var π = "Assets/Howl/Editor/Core/FileSystem.cs";
        var x = File.ReadAllText(π);
        var ㄸ = x * Map.@default;
        o(! ㄸ.Contains("using float"));
    }

}
