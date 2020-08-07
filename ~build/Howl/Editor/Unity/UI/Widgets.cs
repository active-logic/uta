using System;
using UnityEngine; using UnityEditor;
using static UnityEngine.GUILayout;
using static UnityEditor.EditorStyles;
using EGL = UnityEditor.EditorGUILayout;
using static UnityEngine.Color;

namespace Active.Howl.UI{

public static class Widgets{

    static Color lightGray = Color.white * 0.5f;

    internal static void Ruler(int w = 2, int padding = 10){
        var r = EGL.GetControlRect(Height(padding + w));
        r.height = w; r.x -= 2; r.width += 6; r.y += padding/2;
        EditorGUI.DrawRect(r, lightGray);
    }

    internal static void Section(string s, int top = 8, int bottom = 4){
        if (s == null) return;
        Space(top);
        if (s == "Active Logic") That.GUI.LinkToAL(s);
        else Label(s, boldLabel);
        Space(bottom);
    }

    // --------

    /*
    ∘ ┈ LinkToAL(ㄹ header){
        BeginHorizontal();
        BeginVertical();
        Label(header, boldLabel);
        Label("Behavior Tree Library for C# 7",
              miniLabel);
        EndVertical();
        FlexibleSpace();
        That.GUI.Badge("GET!",
              $"{AssetStore}/tools/ai/active-logic-151850", -1);
        EndHorizontal();
    }
    */

}}
