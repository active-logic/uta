
namespace That{ public static class Logger{ public static

    bool enabled{ set{ log.ε=value; } }

}}public class log{

    public static string message { set{ if (ε) UnityEngine.Debug.Log($"(•ᴗ•)ノ 〜 {value}");  }}
    public static string warning { set{ if (ε) UnityEngine.Debug.LogWarning($"(」°ロ°)」〜 {value}"); }}
    public static string error   { set{ if (ε) UnityEngine.Debug.LogError($"(╬`益´)」〜 {value}");  }}

    internal static bool ε = true;

}
