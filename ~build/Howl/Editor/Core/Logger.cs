using System;

public class log{

    public static string message { set => UnityEngine.Debug.Log($"(•ᴗ•)ノ 〜 {value}");  }
    public static string warning { set => UnityEngine.Debug.LogWarning($"(」°ロ°)」〜 {value}"); }
    public static string error   { set => UnityEngine.Debug.LogError($"(╬`益´)」 〜 {value}"); }

}
