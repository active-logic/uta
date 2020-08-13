#if UNITY_EDITOR
using U = UnityEngine;
#endif

namespace That{ public static class Logger{ public static

    bool enabled{ set{ log.ε=value; }  }

    #if UNITY_EDITOR
    public static void Log  (object x) => U.Debug.Log(x);
    public static void Err  (object x) => U.Debug.LogError(x);
    public static void Warn (object x) => U.Debug.LogWarning(x);
    #else
    public static void Log  (object x) => log.Print(x);
    public static void Err  (object x) => log.Print(x);
    public static void Warn (object x) => log.Print(x);
    #endif

}}

public class log{

    #if UNITY_EDITOR
    public static string message { set{ if (ε) That.Logger.Log($"(•ᴗ•)ノ 〜 {value}");  }}
    public static string warning { set{ if (ε) That.Logger.Warn($"(」°ロ°)」〜 {value}"); }}
    public static string error   { set{ if (ε) That.Logger.Err($"(╬`益´)」〜 {value}");  }}
    #else
    public static string message { set{ if (ε) Print($"(•ᴗ•)ノ 〜 {value}");  }}
    public static string warning { set{ if (ε) Print($"(」°ロ°)」〜 {value}"); }}
    public static string error   { set{ if (ε) Print($"(╬`益´)」〜 {value}");  }}
    public static void Print(object x) => System.Console.WriteLine(x);
    #endif

    internal static bool ε = true;

}
