using static That.GUI;
using Active.Howl.Util;

namespace Active.Howl.Test{
public static class GiveBackMon{

    public static bool UI () => V(
       Hd($"GiveBack [{ι.useCount}/{GiveBack.τ}]"),
       B("Max use count", ι.MaxUseCount),
       B("Clear use count", ι.ClearUseCount),
       Tg("didViewOptions", ref ι.didViewOptions),
       Tg("showOptions", ref ι.showOptions)
    );

    static GiveBack ι => GiveBack.ι;

}}
