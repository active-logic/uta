using System.Linq;

namespace Active.Howl{
public static class Stats{

    public static long Size(string π, string pattern)
    => FileSystem.Paths(π, pattern).Sum( x => x.Size() );

    public static long DrySize(string π, string pattern)
    => FileSystem.Paths(π, pattern).Sum( x => x.DrySize() );

    public static int StatementCount(string π, string pattern)
    => FileSystem.Paths(π, pattern).Sum( x => x.StatementCount() );

    public static float ratio      => sourceSize/buildSize;
    public static float buildSize  => DrySize(Path.buildRoot, "*" + Path._Cs);
    public static float sourceSize => DrySize(Path.howlRoot, "*" + Path._Howl);
    public static float statements => StatementCount(Path.howlRoot, "*" + Path._Howl);

}}
