namespace Active.Howl{
public static class Requirements{

    public static bool hasIDE  => atom.Exists() || vscode.Exists();
    public static bool hasExt  => atom.SupportsHowl() || vscode.SupportsHowl();
    public static bool hasRoot => Path.FindHowlRoot() != null;
    public static bool mayImport => false;
    public static bool hasVCS => FileSystem.FindInParent(Path.howlRoot, ".git") != null;
    public static bool hereBeHowls => FileSystem.HasFileOfType("Assets/", "*.howl");

    static Atom   atom   => new Atom();
    static VSCode vscode => new VSCode();

}}
