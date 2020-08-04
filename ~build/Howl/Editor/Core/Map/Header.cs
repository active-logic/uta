
namespace Active.Howl{
public class Header{

    string @value;

    public static Header H(string v) => new Header(){ @value = v };

    public static Rep operator + (Header x, Rep y){
        y.header = x.value;
        return y;
    }

}}
