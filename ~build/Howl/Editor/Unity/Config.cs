using System;
using UnityEngine; using UnityEditor;
using Reload = UnityEditor.AssemblyReloadEvents;
using Editor = UnityEditor.EditorApplication;

namespace Active.Howl{
[System.Serializable] public class Config{

    const string path = "Howl.cfg";  private static Config instance;

    public bool ignoreConflicts, allowImport, allowExport, showTips=true;
    public UserChoice sel_importFiles;
    public DateTime   lastExportDate;
    public DateTime   lastLocSample;
    public int linesOfCode;

    // --------------------------------------------------------------

    public void Save () => path.WriteObject(this);

    // --------------------------------------------------------------

    public static Config ι{get{
        if (instance == null){
            var now = DateTime.Now;
            var _24Hours = TimeSpan.FromHours(24);
            //
            instance = path.ReadObject(new Config());
            instance.lastExportDate = now;
            // Update loc count if stale
            var sampleAge = (now - instance.lastLocSample);
            if (instance.linesOfCode == 0 || sampleAge > _24Hours){
                instance.lastLocSample = now;
                instance.linesOfCode = Stats.loc;
            }
            //
            Reload.beforeAssemblyReload += instance.Save;
            Editor.quitting             += instance.Save;
        }
        return instance;
    }}

}}
