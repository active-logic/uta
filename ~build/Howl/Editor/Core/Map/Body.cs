
namespace Active.Howl{
public class Body{

    string @value;

    public static Body B(string v) => new Body(){ @value = v };

    public static Rep operator * (Rep x, Body y){
        x.body = y.@value;
        return x;
    }

}}
