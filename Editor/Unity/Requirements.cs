namespace Active.Howl{
public class Requirements{

    public bool hasIDE  => atom.Exists() || vscode.Exists();
    public bool hasExt  => atom.SupportsHowl() || vscode.SupportsHowl();
    public bool hasRoot => Path.FindHowlRoot() != null;
    public bool mayImport => false;
    public bool hasVCS => FileSystem.FindInParent(Path.howlRoot, ".git") != null;
    public bool hereBeHowls => FileSystem.HasFileOfType("Assets/", "*.howl");

    static Atom   atom   => new Atom();
    static VSCode vscode => new VSCode();

}}
