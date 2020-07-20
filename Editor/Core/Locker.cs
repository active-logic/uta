using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Locker{

    public static void Apply(ㄹ ㅂ, ㄹ ext, ㅇ @lock){
        foreach(var x in FileSystem.Paths(ㅂ, ext)){
            if(@lock) Lock(x); else Unlock(x);
        }
    }

    public static void Lock(ㄹ π)
    => File.SetAttributes(π, FileAttributes.ReadOnly);

    public static void Unlock(ㄹ π){
        var x = File.ReadAllText(π);
        File.Delete(π);
        File.WriteAllText(π, x);
    }

}}
