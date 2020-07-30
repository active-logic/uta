using System;
using UnityEditor; using static UnityEngine.GUILayout;

namespace That{ internal static class GUI{

    internal static bool flex{ get{ FlexibleSpace(); return true; } }

    internal static bool B(string label, Action X){
        if (Button(label)){ X(); return true; }
        else return false;
    }

    internal static Widget H
    { get{ BeginHorizontal(); return (x) => { EndHorizontal(); return true; }; } }

    internal static Widget V
    { get{ BeginVertical(); return (x) => { EndVertical(); return true; }; } }

    internal static EditorWindow W<T>(string title) where T : EditorWindow
    => EditorWindow.GetWindow<T>(title: title);

    public delegate bool Widget(params object[] args);

}}
