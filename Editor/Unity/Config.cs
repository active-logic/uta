using System.IO; using System.Text;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using UnityEngine;
using UnityEditor;

namespace Active.Howl{
public class Config{

    public static ㅇ ignoreConflicts
    { get => Get("c"); set => Set("c", value); }

    public static ㅇ allowImport
    { get => Get("i"); set => Set("i", value); }

    public static ㅇ allowExport
    { get => Get("e"); set => Set("e", value); }

    static ㅇ Get(ㄹ flag)
    => EditorPrefs.GetBool("Howl." + flag);

    static void Set(ㄹ flag, ㅇ value)
    => EditorPrefs.SetBool("Howl." + flag, value);

}}
