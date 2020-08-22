# Howl - Getting started with Unity 3D

After adding the package to your project hit `Window > Activ > Howl` to configure your environment. As with C#, your Howl scripts will recompile whenever the editor gains focus.

In a typical workflow you create *.howl sources and the integration maintains an `Assets/~build` directory holding C# output.

Import/Export allow either converting legacy source files, or reconverting to C#. These options are disabled by default.

**Ensure your project is backed up and/or uses VCS before importing legacy sources**.

Once enabled via the Howl window, import/export is available either via the Howl window, or via the project window (context menu).

## Good to know

**Use the Unity project window to move and delete Howl scripts**. This is similar to how Unity does not like you modifying files outside the editor.

Unity needs to see the C# output in order to build your project. We keep the C# output under `Assets/~build`. It is okay to move/rename this but if you do so, close Unity first and do it manually.

If you are using **assemblies**:

- Howl supports *.asmdef on import. Your assembly definitions are placed in the `~build` directory.
- Edit assembly definitions as normal, except they now live inside the `~build` directory.
- Do not mix Howl and C# sources in the same assembly; this is not supported and you will get errors.
- Do not delete the `~build` directory (or lose your assembly definitions).
- Currently you may only have ONE `~build` directory.

Should you wish to create a new assembly for your Howl scripts:

1) Create the assembly normally. The same way that you create assemblies for C# sources.
2) Right click on the assembly and select `Use Howl`.

Howl generates *.asmdt token files which are just house-keeping so we know where to find the C# assemblies.
