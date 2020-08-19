using static System.Math;

namespace Active.Howl.Util{
[System.Serializable] public class GiveBack{

    public const int τ = 100;
    public bool didViewOptions, showOptions;
    //
    public int useCount{
           get{ return _useCount; }
        private set{
                _useCount = value;
                if (didMaxUseCount && !didViewOptions)
                showOptions = true;
             }
    } int _useCount;

    public bool displayNotice  => didMaxUseCount &&  !didViewOptions;
    public bool didMaxUseCount => useCount >= τ;

    public void Dismiss           () => showOptions = !(didViewOptions = true);
    public void ClearUseCount     () => useCount = 0;
    public void IncrementUseCount () => useCount++;
    public void MaxUseCount       () => useCount = Max(useCount, τ);

    public static GiveBack ι => Active.Howl.Config.ι.giveback ;

    override public string ToString () =>
          $"did view options? {didViewOptions}, "
        + $"show options ? {showOptions}, "
        + $"displayNotice? {displayNotice}, "
        + $"didMaxUseCount? {didMaxUseCount}";

}}
