using InvOp = System.InvalidOperationException;
using ArgEx = System.ArgumentException;
using NUnit.Framework;
using Active.Howl; using static Active.Howl.Path;

namespace Unit{ public class PathTest : TestBase {

    [Test] public void BuildPath_file()
    => o($"{howlRoot}x.howl".BuildPath(), $"{buildRoot}x.cs");

    [Test] public void BuildPath_file_in_dir()
    => o($"{howlRoot}Runtime/x.howl".BuildPath(),
         $"{buildRoot}Runtime/x.cs");

    [Test] public void BuildPath_file_w_full_path(){
        var ㅂ = "Assets/Howl/x.howl".FullPath();
        var ㄸ = ㅂ.BuildPath();
        o(ㄸ, $"{buildRoot}Howl/x.cs");
    }

    [Test] public void BuildPath_dir
    () => o( $"{howlRoot}Pkg/".BuildPath(), $"{buildRoot}Pkg/" );

    [Test] public void BuildPath_dir_no_final_sep
    () => o( $"{howlRoot}Pkg".BuildPath(), $"{buildRoot}Pkg" );

    [Test] public void BuildPath_reject_bad_extension
    () => Assert.Throws<InvOp>( () => "x.foo".BuildPath() );

    [Test] public void BuildPath_bad_root
    () => Assert.Throws <InvOp>( () => "Fakeroot/x.howl".BuildPath() );

    [Test] public void BuildRoot () => o( buildRoot, "Assets/Howl/~build/" );

    [Test] public void DefaultHowlRootPath () => o( defaultHowlRoot, "Assets/Howl.Howl/");

    [Test] public void HasBuildImage_accept_existing_file
    () => o( $"{howlRoot}Howl/Editor/Util/Cache.howl".HasBuildImage() );

    [Test] public void HasBuildImage_accept_existing_dir
    () => o( $"{howlRoot}Howl/Editor/Util/".HasBuildImage() );

    [Test] public void HasBuildImage_reject_asset_from_build_dir
    () => o( !$"{buildRoot}/Howl/Editor/Util/Cache.cs".HasBuildImage() );

    [Test] public void HasBuildImage_reject_asset_without_howl_root
    () => o( !$"{howlRoot}/../Cache.howl".HasBuildImage() );

    [Test] public void HasBuildImage_reject_non_existent_file
    () => o( !$"{howlRoot}Howl/Editor/Util/Dash.howl".HasBuildImage() );

    [Test] public void HowlRoot() => o( howlRoot, "Assets/" );

    [Test] public void IsHowlBound
    () => o( $"{buildRoot}Howl/Editor/Util/Cache.cs".IsHowlBound() );

    [Test] public void IsHowlBound_false () => o( !$"Assets/Foo.cs".IsHowlBound() );

    [Test] public void PathToMetaFile1 () => o( "Assets/Foo.cs".PathToMetaFile(),
                           "Assets/Foo.cs.meta" );

    [Test] public void PathToMetaFile2 () => o( "Assets/Foo/".PathToMetaFile(),
                           "Assets/Foo.meta" );

    [Test] public void MetaFile1 () => o( "Assets/Foo.cs".MetaFile(), null );

    [Test] public void MetaFile2 () => o( "Assets/Howl".MetaFile(), "Assets/Howl.meta" );

    [Test] public void MetaFile3 () => o( "Assets/Howl/".MetaFile(), "Assets/Howl.meta");

    [Test] public void ProjectName () => o (projectName, "Howl");

    [Test] public void SetExtension () => o( "Bumblebee.gif".SetExtension(".tiff"),
                        "Bumblebee.tiff" );

    [Test] public void SourcePath () => o( $"{buildRoot}Pkg/Test.cs".SourcePath(),
                      $"{howlRoot}Pkg/Test.howl");

    [Test] public void SourcePath_dir1 () => o( $"{buildRoot}Pkg/".SourcePath(),
                      $"{howlRoot}Pkg/");

    [Test] public void SourcePath_dir2 () => o( $"{buildRoot}Pkg".SourcePath(),
                      $"{howlRoot}Pkg");

    [Test] public void SourcePath_BadInput
    () => Assert.Throws <ArgEx>(  () => "Foo/Bar/Pkg/Test.cs".SourcePath() );

    [Test] public void IsHowlSource_file(){
        var π = $"{howlRoot}Test.howl";
        o(π.IsHowlSource(), true);
        o(π.FullPath().IsHowlSource(), true);
    }

    [Test] public void IsHowlSource_reject_non_howl_files
    () => o( $"{howlRoot}Test.gif".IsHowlSource(), false );

    [Test] public void IsHowlSource_reject_dirs(){
        var π = $"{howlRoot}Pkg/Dir";
        o(π.IsHowlSource(), false);
        o(π.FullPath().IsHowlSource(), false);
    }

    [Test] public void Nix() => o("Assets\\Howl".Nix(), "Assets/Howl");

    [Test] public void NoFinalSep([Values("Foo/", "Foo")] string x)
    => o( x.NoFinalSep() , "Foo");

    [Test] public void NoFinalSep_BS() => o( ("Foo" + '\\').NoFinalSep() , "Foo");

    [Test] public void RelativeTo_0
    () => o("Assets/Pkg/Foo/Bar".RelativeTo("Assets/Pkg"), "Foo/Bar");

    [Test] public void RelativeTo_1
    () => o("Assets/Howl/Editor/Unity/Config.cs"
      .RelativeTo("Assets/Howl/Editor/Unity"), "Config.cs");

}}
