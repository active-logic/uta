using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using InvOp = System.InvalidOperationException;
using UnityEngine;

namespace Active.Howl{
public static class Path{

    public static ㄹ _Howl = ".howl", _Cs = ".cs";

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
        var π = "Assets/";
        if(!ㅂ.StartsWith(π)){
            var i = ㅂ.IndexOf(π);
            if(i < 0) throw new InvOp($"{ㅂ} not in {π}");
            ㅂ = ㅂ.Substring(i);
        }
        var ㄸ = ㅂ.Substring(π.Length).Replace(".cs", ".howl");
        return $"{howlRoot}{ㄸ}";
    }

    public static ㄹ howlRoot => $"Assets/{projectName}.Howl/";

    public static ㄹ projectName{ get{
        ㄹ[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }}

}}