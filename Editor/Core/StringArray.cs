using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public static class StringArray{

    public static ㄹ Join(this ㄹ[] x) => ㄹ.Join("", x);

    public static ㄹ Join(this ㄹ[] x, char c)
    => ㄹ.Join(c.ToString(), x);

}}
