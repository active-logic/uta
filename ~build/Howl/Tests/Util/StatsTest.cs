//⊐ System.Linq;
using NUnit.Framework;
using Active.Howl;
using static Active.Howl.Stats;

namespace Unit{
public class StatsTest : TestBase{

    [Test] public void SourceSize  () =>  That.Logger.Log($"Source: {sourceSize:#,0}");
    [Test] public void BuildSize   () =>  That.Logger.Log($"Build : {buildSize:#,0}");
    [Test] public void Ratio       () =>  That.Logger.Log($"Ratio : {ratio:#.##}");
    [Test] public void LinesOfCode () =>  That.Logger.Log($"Lines : {loc:#,0}");
    [Test] public void FilesOver   () =>  That.Logger.Log($"Files over 34: {largeFiles.Join(", ")}");

}}
