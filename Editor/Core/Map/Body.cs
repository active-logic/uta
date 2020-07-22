using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;

namespace Active.Howl{
public class Body{

    ㄹ @value;

    public static Body B(ㄹ v) => new Body(){ @value = v };

    public static Rep operator * (Rep x, Body y){
        x.body = y.@value;
        return x;
    }

}}
