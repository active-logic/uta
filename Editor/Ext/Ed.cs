
namespace Active.Howl{
public interface Ed{

    string GenUserSnippets(bool dry);

    void SetUserSnippetsPath(string ㅂ);

    string DefaultUserSnippetsPath(bool expand);

    string Name();

    string UserSnippetsPath(bool expand);

}}
