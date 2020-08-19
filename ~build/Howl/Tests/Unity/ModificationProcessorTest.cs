using NUnit.Framework;
using Active.Howl;
using static UnityEditor.AssetMoveResult;
using MP = Active.Howl.ModificationProcessor;

namespace Unit{
public class ModificationProcessorTest : TestBase{

    const string PathInBuild = "Assets/Howl/~build/anywhere";

    [Test] public void IsInBuild () => o(PathInBuild.In(Path.buildRoot));

    [Test] public void OnWillMoveAsset(){
        o(MP.OnWillMoveAsset("Scene.unity", PathInBuild),
          FailedMove);
    }

}}
