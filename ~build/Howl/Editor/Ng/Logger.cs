#if !UNITY_2018_1_OR_NEWER
namespace That{ public static class Logger{ public static

    bool enabled{ set{ log.ε=value; }  }

    public static void Log  (object x) => log.Print(x);
    public static void Err  (object x) => log.Print(x);
    public static void Warn (object x) => log.Print(x);

}}

public class log{

    public static string message { set{ if (ε) Print($"(•ᴗ•)ノ 〜 {value}");  }}
    public static string warning { set{ if (ε) Print($"(」°ロ°)」〜 {value}"); }}
    public static string error   { set{ if (ε) Print($"(╬`益´)」〜 {value}");  }}
    public static void Print(object x) => System.Console.WriteLine(x);
    internal static bool ε = true;

}
#endif
