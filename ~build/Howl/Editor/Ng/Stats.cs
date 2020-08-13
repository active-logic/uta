using System.Linq;

namespace Active.Howl{
public static class Stats{

   const string howl = "*.howl";
   static string ρ = Path.howlRoot;

   public static float ratio      => sourceSize/buildSize;
   public static float buildSize  => DrySize(Path.buildRoot, "*" + Path._Cs);
   public static float sourceSize => DrySize(ρ, howl);
   public static string[] largeFiles => FilesOver(ρ, 34, howl);
   public static int loc => StatementCount(ρ, howl);
   public static int δloc => loc - Config.ι.linesOfCode;

   public static string[] FilesOver(string π, int n, string pattern)
   => (from x in FileSystem.Paths(π, pattern)
      where x.NumberOfLines() > n
      orderby x.NumberOfLines() descending
      select x.FileName().Replace(".howl", "")).ToArray();

   public static long DrySize(string π, string pattern)
   => FileSystem.Paths(π, pattern).Sum( x => x.DrySize() );

   public static long Size(string π, string pattern)
   => FileSystem.Paths(π, pattern).Sum( x => x.Size() );

   public static int StatementCount(string π, string pattern)
   => FileSystem.Paths(π, pattern).Sum( x => x.StatementCount() );

}}
