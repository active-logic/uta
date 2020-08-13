
namespace That{ public static class Logger{ public static

    bool enabled{ set{ log.ε=value; } }

}}

public class log{

    #if UNITY_EDITOR

    public static string message { set{ if (ε) UnityEngine.Debug.Log($"(•ᴗ•)ノ 〜 {value}");  }}
    public static string warning { set{ if (ε) UnityEngine.Debug.LogWarning($"(」°ロ°)」〜 {value}"); }}
    public static string error   { set{ if (ε) UnityEngine.Debug.LogError($"(╬`益´)」〜 {value}");  }}

    #else

    public static string message { set{ if (ε) Print($"(•ᴗ•)ノ 〜 {value}");  }}
    public static string warning { set{ if (ε) Print($"(」°ロ°)」〜 {value}"); }}
    public static string error   { set{ if (ε) Print($"(╬`益´)」〜 {value}");  }}

    public static void Print(object x) => System.Console.WriteLine(x);

    #endif

    internal static bool ε = true;

}
