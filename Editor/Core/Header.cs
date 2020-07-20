using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Header{

    ㄹ @value;

    public static Header H(ㄹ v) => new Header(){ @value = v };

    public static Rep operator + (Header x, Rep y){
        y.header = x.value;
        return y;
    }

}}
