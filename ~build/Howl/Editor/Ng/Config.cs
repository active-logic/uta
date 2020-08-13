using System;
using SerialEx = System.Runtime.Serialization.SerializationException;
#if UNITY_EDITOR
using Reload = UnityEditor.AssemblyReloadEvents;
using Editor = UnityEditor.EditorApplication;
#endif

namespace Active.Howl{
[System.Serializable] public class Config  {

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
            try {
                instance = path.ReadObject(new Config());
            } catch (SerialEx){
                log.warning = "Reset config (format has changed)";
                instance = new Config();
            }
            instance.lastExportDate = now;
            // Update loc count if stale
            var sampleAge = (now - instance.lastLocSample);
            if (instance.linesOfCode == 0 || sampleAge > _24Hours){
                instance.lastLocSample = now;
                instance.linesOfCode = Stats.loc;
            }
            #if UNITY_EDITOR
            Reload.beforeAssemblyReload += instance.Save;
            Editor.quitting             += instance.Save;
            #endif
        }
        return instance;
    }}

}}
