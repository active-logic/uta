using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

public class Snippet{

    public ㄹ name, prefix, body;

    public static implicit operator Snippet((ㄹ name,
                                             ㄹ prefix,
                                             ㄹ body) that)
    => new Snippet()
    { name = that.name, prefix = that.prefix, body = that.body};

    override public ㄹ ToString()
    => $"{name}: {prefix} => |{body}|";

}
