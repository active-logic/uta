#if !UNITY_2018_1_OR_NEWER

using static Active.Howl.Mood;

namespace That{ public static class Logger{ public static

    bool enabled{ set{ log.ε=value; }  }

    public static void Log  (object x) => log.Print(x);
    public static void Err  (object x) => log.Print(x);
    public static void Warn (object x) => log.Print(x);

}}

public class log{

    public static string message { set{ if (ε) Print($"{happy} 〜 {value}"); }}
    public static string warning { set{ if (ε) Print($"{antsy} 〜 {value}"); }}
    public static string error   { set{ if (ε) Print($"{angry} 〜 {value}"); }}

    public static void Print(object x) => System.Console.WriteLine(x);

    internal static bool ε = true;

}

#endif  // UNITY_2018_1_OR_NEWER
