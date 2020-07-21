using System.IO;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class StringArray{

    public static ㄹ Join(this ㄹ[] x) => ㄹ.Join("", x);

    public static ㄹ Join(this ㄹ[] x, char c = '\n')
    => ㄹ.Join(c.ToString(), x);

    public static void Write(this ㄹ[] ㅂ, ㄹ path, char sep = '\n')
    => File.WriteAllText(path, ㅂ.Join(sep)
                               + (sep == '\n' ? "\n" : null));

}}
