using System.IO; using System.Text;
using UnityEngine;
using UnityEditor;

namespace Active.Howl{
public class Config{

    public static bool ignoreConflicts{
        get => Get("c");
        set => Set("c", value);
    }

    public static bool allowImport{
        get => Get("i");
        set => Set("i", value);
    }

    public static bool allowExport{
        get => Get("e");
        set => Set("e", value);
    }

    static bool Get(string flag) => EditorPrefs.GetBool("Howl." + flag);

    static void Set(string flag, bool w) => EditorPrefs.SetBool("Howl." + flag, w);

}}
