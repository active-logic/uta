using NUnit.Framework;
using static Active.Howl.Stats;

namespace Unit{
public class StatsTest : TestBase{

    [Test] public void SourceSize  () =>  UnityEngine.Debug.Log($"Source: {sourceSize:#,0}");
    [Test] public void BuildSize   () =>  UnityEngine.Debug.Log($"Build : {buildSize:#,0}");
    [Test] public void Ratio       () =>  UnityEngine.Debug.Log($"Ratio: {ratio:#.##}");
    [Test] public void Statements  () =>  UnityEngine.Debug.Log($"Statements: {statements:#,0}");

}}
