using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using EGL = UnityEditor.EditorGUILayout;
using static UnityEngine.Color;

namespace Active.Howl.UI{
internal static class Widgets{

    const ㄹ AssetStore = "https://assetstore.unity.com/packages";

    static Color lightGray = Color.white * 0.5f;

     internal static void Badge(ㄹ label, ㄹ ㄸ, ᆞ w = 24, Color? bg = null,
                                                Color? fg = null){
        var oldbg = GUI.backgroundColor;
        var style = new GUIStyle(GUI.skin.button);
        style.normal.textColor = fg ?? Color.black;
        GUI.backgroundColor = bg ?? Color.white;
        ㅇ ㅂ = w > 0 ? Button(label, style, Width(24)) : Button(label, style);
        if(ㅂ) Application.OpenURL(ㄸ);
        GUI.backgroundColor = oldbg;
    }

    internal static void Ruler(int w = 2, int padding = 10){
        var r = EGL.GetControlRect(Height(padding + w));
        r.height = w; r.x -= 2; r.width += 6; r.y += padding/2;
        EditorGUI.DrawRect(r, lightGray);
    }

    internal static void Section(ㄹ s){
        if(s == null) return;
        Space(8);
        if(s == "Active Logic") LinkToAL(s);
        else                    Label(s, boldLabel);
    }

    // --------

    static void LinkToAL(ㄹ header){
        BeginHorizontal();
        BeginVertical();
        Label(header, boldLabel);
        Label("Behavior Tree Library for C# 7",
              miniLabel);
        EndVertical();
        FlexibleSpace();
        Badge("GET!",
              $"{AssetStore}/tools/ai/active-logic-151850", -1);
        EndHorizontal();
    }

}}
