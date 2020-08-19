using UnityEngine; using UnityEditor;

namespace Active.Howl.Util{ [InitializeOnLoad] public class  GiveBackNotice{

    static GiveBackNotice(){
        if (GiveBack.ι.displayNotice)

log.message = @"Finding Howl useful? To support further development,
kindly visit the Howl window.";

    }

}}
