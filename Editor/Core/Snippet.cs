
public class Snippet{

    public string name, prefix, body;

    public static implicit operator Snippet((string name,
                                             string prefix,
                                             string body) that)
    => new Snippet()
    { name = that.name, prefix = that.prefix, body = that.body};

    override public string ToString()
    => $"{name}: {prefix} => |{body}|";

}
