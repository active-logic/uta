
namespace Active.Howl{
public interface Ed {

    string UserSnippetsPath(bool expand);
    string DefaultUserSnippetsPath(bool expand);
    //
    string GenUserSnippets(bool dry);
    void SetUserSnippetsPath(string ㅂ);

    bool CanHideBuildDir();
    bool IsBuildDirHidden();
    //
    void HideBuildDir(bool flag);

    bool Exists();
    bool SupportsHowl();
    string Name();

}}
