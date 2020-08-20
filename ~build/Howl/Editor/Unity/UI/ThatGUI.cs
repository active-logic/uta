using System;
using App = UnityEngine.Application;
using UnityEngine; using UnityEditor; using static UnityEngine.GUILayout;
using static UnityEngine.Color; using static UnityEditor.EditorStyles;
using EGL = UnityEditor.EditorGUILayout; using UGUI = UnityEngine.GUI;
using EGU = UnityEditor.EditorGUIUtility;
using C = Active.Howl.Config; using S = Active.Howl.UIStrings;
using static Active.Howl.UI.Widgets;

namespace That{ public static class GUI{

    static Color lightGray = Color.white * 0.5f;

    // TODO migrate
    const string AssetStore = "https://assetstore.unity.com/packages";

    public static bool flex{ get{ FlexibleSpace(); return true; } }

    public static bool A(string label, string url, int width = -1){
        bool ㄸ = width < 0 ? Button(label) : Button(label, Width(width));
        if (ㄸ){ App.OpenURL(url); return true; }
        else return false;
    }

    public static bool B(string label, Action X = null, GUIStyle style=null ){
        if (style == null ? Button(label) : Button(label, style)){
            if (X != null) X(); return true;
        }
        else return false;
    }

    public static bool Badge(string label, string ㄸ, int w=24, Color? bg = null, Color? fg = null){
        var oldbg = UGUI.backgroundColor;
        var style = new GUIStyle(UGUI.skin.button);
        style.normal.textColor = fg ?? Color.black;
        UGUI.backgroundColor = bg ?? Color.white;
        bool ㅂ = w > 0 ? Button(label, style, Width(24))
                     : Button(label, style);
        if(ㅂ) Application.OpenURL(ㄸ);
        UGUI.backgroundColor = oldbg;
        return true;
    }

    public static bool Br(int space=8){ GUILayout.Space(space); return true; }

    public static bool P(string label, GUIStyle style=null, params GUILayoutOption[] opt){
        if(style != null) style.richText = true;
        if (style != null) Label(label, style, opt);
        else Label(label, opt);
        return true;
    }

    public static Scope H
       { get{ BeginHorizontal(); return (x) => { EndHorizontal(); return true; }; } }

    public static bool Hd(string s, int top = 8, int bottom = 4){
        if (s == null) return true;
        Space(top);
        if (s == "Active Logic") LinkToAL(s);
        else Label(s, boldLabel);
        Space(bottom);
        return true;
    }

    public static bool Hr(int w = 2, int padding = 10, int count = 1){
        for (int i = 0; i < count; i++){
            var r = EGL.GetControlRect(Height(padding + w));
            r.height = w; r.x -= 2; r.width += 6; r.y += padding/2;
            EditorGUI.DrawRect(r, lightGray);
        } return true;
    }

    // TODO migrate
    public static void LinkToAL(string header){
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

    public static bool Tg(string label, ref bool property)
       { property = Toggle(property, label); return true; }

    public static bool Tg(string label, Action<bool> Setter, Func<bool> Getter)
       { Setter( Toggle(Getter(), label)); return true; }

    public static Scope V{get{ BeginVertical(); return (x) => { EndVertical(); return true; }; }}

    public static EditorWindow W<T>(string title) where T : EditorWindow
       => EditorWindow.GetWindow<T>(title: title);

    // ---------------------------------------------------------------

    public static whenGate @when(bool cond){
        EditorGUI.BeginDisabledGroup(!cond);
        return new whenGate();
    }

    public static ifGate? @if(bool cond){
        return cond ? new ifGate() : (ifGate?)null;
    }

    // Implementation ================================================

    public delegate bool Scope(params  object[] args);

    public readonly struct whenGate{
        public bool this[params object[] λ]{
            get{ EditorGUI.EndDisabledGroup(); return true; }
        }
    }

    public readonly struct ifGate{
        public bool this[params object[] λ] => true;
    }

}}
