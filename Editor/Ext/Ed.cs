
namespace Active.Howl{
public interface Ed{

    string GenUserSnippets(bool dry);

    void SetUserSnippetsPath(string ㅂ);

    string UserSnippetsPath(bool expand);

    string DefaultUserSnippetsPath(bool expand);

    bool Exists();

    bool SupportsHowl();

    string Name();


}}
