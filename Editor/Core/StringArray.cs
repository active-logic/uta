using System.IO;

namespace Active.Howl{
public static class StringArray{

    public static string Join(this string[] x) => string.Join("", x);

    public static string Join(this string[] x, char c = '\n')
    => string.Join(c.ToString(), x);

    public static string Join(this string[] x, string s)
    => string.Join(s, x);

    public static void Write(this string[] ㅂ, string path, char sep = '\n')
    => File.WriteAllText(path, ㅂ.Join(sep)
                               + (sep == '\n' ? "\n" : null));

}}
