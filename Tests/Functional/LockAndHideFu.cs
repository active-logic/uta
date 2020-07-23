using System.IO;
using NUnit.Framework;
using static System.IO.FileAttributes;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Functional{
public class LockAndHideFu : FunctionalTest{

    [Test] public void Lock(){
        var π = "Assets/test.xyz";
        Create(π);
        File.SetAttributes(π, ReadOnly);
        o(File.GetAttributes(π), ReadOnly);
        #if UNITY_EDITOR_WIN
        // On Windows a ReadOnly file cannot be deleted
        File.SetAttributes(π, Normal);
        #endif
        Delete(π);
        o(File.Exists(π), false);
    }

    [Test] public void HideFlag_NotHonored_OnMacOS(){
        var π = "Assets/test.xyz";
        Create(π);
        File.SetAttributes(π, Hidden);
        #if UNITY_EDITOR_OSX
        o(File.GetAttributes(π) == Hidden, false);
        #else
        o(File.GetAttributes(π) == Hidden, true);
        #endif
        Delete(π);
        o(File.Exists(π), false);
    }

}}
