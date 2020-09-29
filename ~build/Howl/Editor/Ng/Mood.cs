namespace Active.Howl{
public static class Mood{

    public static string happy = "(•ᴗ•)ノ";
    public static string antsy = "(°ロ°)」";
    public static string angry = "(`益´)」";

    static Mood(){
        if (!OS.runtime.Contains("osx")){
            happy = "('v')";
            antsy = "('~')";
            angry = "(`^´)";
        }
    }

}}
