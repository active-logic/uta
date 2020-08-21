using System; using System.Diagnostics; using System.Text; using System.Threading;
using ArgEx = System.ArgumentException;

namespace Active.Howl{
public static class Runner{

    public static string Cmd(string cmd, string args, string workdir, bool dry=true) {
        if (workdir == null) throw new ArgEx("Better have a work dir");
        else if (dry) return $"{cmd} {args}";
        else using (var φ = new Process()){
            φ.StartInfo.WorkingDirectory = workdir;
            φ.StartInfo.FileName         = cmd;
            φ.StartInfo.Arguments        = args;
            φ.StartInfo.UseShellExecute  = true;
            φ.StartInfo.CreateNoWindow   = true;
            φ.Start();
            φ.WaitForExit();
        } return null;

    }

}}
