//⊐ System.Linq;
using NUnit.Framework;
using Active.Howl;
using static Active.Howl.Stats;

namespace Unit{
public class StatsTest : TestBase{

    [Test] public void SourceSize  () =>  UnityEngine.Debug.Log($"Source: {sourceSize:#,0}");
    [Test] public void BuildSize   () =>  UnityEngine.Debug.Log($"Build : {buildSize:#,0}");
    [Test] public void Ratio       () =>  UnityEngine.Debug.Log($"Ratio : {ratio:#.##}");
    [Test] public void LinesOfCode () =>  UnityEngine.Debug.Log($"Lines : {loc:#,0}");
    [Test] public void FilesOverCount
    () => o (largeFiles .Length, 43);
    [Test] public void FilesOver   () =>  UnityEngine.Debug.Log($"Files over 34: {largeFiles.Join(", ")}");
}}
