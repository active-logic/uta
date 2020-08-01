using UnityEngine; using UnityEditor;
using Reload = UnityEditor.AssemblyReloadEvents;
using Editor = UnityEditor.EditorApplication;

namespace Active.Howl{
[System.Serializable]
public class Config{

    const string path = "Howl.cfg";
    private static Config instance;

    public bool ignoreConflicts, allowImport, allowExport;
    public UserChoice sel_importFiles;

    public void Save  () => path.WriteObject(this);

    public static Config ι{get{
        if (instance == null){
            instance = path.ReadObject(new Config());
            Reload.beforeAssemblyReload += instance.Save;
            Editor.quitting             += instance.Save;
        }
        return instance;
    }}

}}
