using self = Active.Howl.Classifier;

namespace Active.Howl{
public class Classifier{

  string _class;

 // public string @class => _class;

  public Classifier(string _class){
    this._class = _class;
  }

  public static self c   => new self("Cat");
  public static self f   => new self("Flow");
  public static self k   => new self("Key");
  public static self m   => new self("Mod");
  public static self o   => new self("Op");
  public static self p   => new self("Pr");
  public static self s   => new self("Const");
  public static self x   => new self("Spe");

  public static self[] all => new self[]{ c, f, k, m, o, p, s, x };

  public static Rep operator * (Rep x, self y){
      x._class = y._class;
      return x;
  }

  public static Rep operator * (self x, Rep y){
      y._class = x._class;
      return y;
  }

  override public string ToString()  => _class;

  public static implicit operator string(Classifier x)
  => x.ToString();

}}
