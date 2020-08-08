public class log{

    public static string message { set => UnityEngine.Debug.Log(value); }
    public static string warning { set => UnityEngine.Debug.LogWarning(value); }
    public static string error   { set => UnityEngine.Debug.LogError(value); }

}
