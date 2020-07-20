using System.IO;
using InvOp = System.InvalidOperationException;
using ㅅ = System.Single;  using ㅇ = System.Boolean;
using ᆞ = System.Int32;   using ㄹ = System.String;
using NUnit.Framework;
using Active.Howl;
using static Active.Howl.Path;

public class HowlTest : TestBase{

    [Test] public void ImportDir(){
        Howl.ImportDir("Assets/");
    }

    [Test] public void ImportFile_MakeOriginalReadOnly(){
        ㄹ ㅂ = "Assets/Test.cs", ㄸ = "Assets/Howl.Howl/Test.howl";
        File.WriteAllText(ㅂ, "");
        Howl.ImportFile(ㅂ, ㄸ);
        // TODO not well formed; should run twice in either mode
        o(File.GetAttributes(ㅂ),
            Config.lockCsFiles ? FileAttributes.ReadOnly
                               : FileAttributes.Normal
        );
        File.Delete(ㅂ);
    }

    [Test] public void Exclude()
    => o(Howl.Exclude("// ▓▒░(°◡°)░▒▓ exclude me"), true);

}
