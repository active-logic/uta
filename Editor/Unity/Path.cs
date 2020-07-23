using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using Env   = System.Environment;
using InvOp = System.InvalidOperationException;
using UnityEngine;

namespace Active.Howl{
public static class Path{

    public static ㄹ _Howl = ".howl", _Cs = ".cs";

    public static ㄹ Expand(this ㄹ path) => path
    .Replace("~",
        Env.GetFolderPath(Env.SpecialFolder.Personal))
    .Replace("%APPDATA%",
        Env.GetFolderPath(Env.SpecialFolder.ApplicationData));

    public static ㅇ IsDetachedHowlSource(this ㄹ π)
    => π.EndsWith(_Howl);

    public static ㅇ IsHowlSource(this ㄹ π)
    => π.StartsWith(howlRoot) && π.EndsWith(_Howl);

    // Given path to a howl, return matching C# path
    public static ㄹ OutPath(this ㄹ ㅂ) => ㅂ.IsHowlSource()
       ? $"Assets/{ㅂ.Substring(howlRoot.Length).Replace(_Howl, _Cs)}"
       : throw new InvOp($"{ㅂ} doesn't howl");

    // Given path to a C# file, return matching Howl path
    public static ㄹ InPath(this ㄹ ㅂ){
        if(!ㅂ.InAssets()){
            var i = ㅂ.IndexOf("Assets");
            if(i < 0) throw new InvOp($"{ㅂ} not in Assets/");
            ㅂ = ㅂ.Substring(i);
        }
        var ㄸ = ㅂ.Substring("Assets/".Length).Replace(".cs", ".howl");
        return $"{howlRoot}{ㄸ}";
    }

    public static bool InAssets(this string path)
    => path.StartsWith("Assets/") || path.StartsWith("Assets\\");

    public static ㅇ InHowlPath(this ㄹ π) => π.StartsWith(howlRoot);

    #if UNITY_EDITOR_WIN
    public static ㄹ howlRoot => $"Assets\\{projectName}.Howl\\";
    #else
    public static ㄹ howlRoot => $"Assets/{projectName}.Howl/";
    #endif

    public static ㄹ projectName{ get{
        // NOTE: Unity always returns data path with forward slashes, even on
        // windows
        ㄹ[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}

}}
