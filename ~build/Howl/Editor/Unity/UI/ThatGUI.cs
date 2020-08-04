using System;
using UnityEditor; using static UnityEngine.GUILayout;
using App = UnityEngine.Application;

namespace That{ internal static class GUI{

    public static bool flex{ get{ FlexibleSpace(); return true; } }

    public static bool A(string label, string url){
        if (Button(label)){ App.OpenURL(url); return true; }
        else return false;
    }

    public static bool B(string label, Action X = null){
        if (Button(label)){ if(X != null) X(); return true; }
        else return false;
    }

    public static bool Br(int space=8){ EditorGUILayout.Space(space); return true; }

    public static bool P(string label){
        Label(label); return true;
    }

    internal static Widget H
    { get{ BeginHorizontal(); return (x) => { EndHorizontal(); return true; }; } }

    internal static Widget V
    { get{ BeginVertical(); return (x) => { EndVertical(); return true; }; } }

    internal static EditorWindow W<T>(string title) where T : EditorWindow
    => EditorWindow.GetWindow<T>(title: title);

    public delegate bool Widget(params object[] args);

}}
