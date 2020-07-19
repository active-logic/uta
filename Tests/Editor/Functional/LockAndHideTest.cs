using System.IO;
using NUnit.Framework;
using static System.IO.FileAttributes;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Functional{
public class LockAndHideTest : FunctionalTest{

    [Test] public void Lock(){
        var π = "Assets/test.xyz";
        Create(π);
        File.SetAttributes(π, ReadOnly);
        o(File.GetAttributes(π), ReadOnly);
        Delete(π);
        o(File.Exists(π), false);
    }

    [Test] public void HideFlag_NotHonored(){
        var π = "Assets/test.xyz";
        Create(π);
        File.SetAttributes(π, Hidden);
        o(File.GetAttributes(π) == Hidden, false);
        Delete(π);
        o(File.Exists(π), false);
    }

}}
