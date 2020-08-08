# Frequently Asked Questions

## Does Howl support assembly definitions?

Yes. When you import C# scripts assemblies are processed too.
However we have to move your assemblies to the ~build dir and please open/edit them 'in place' for now.

## So how do I create a new assembly for Howl scripts?

Create your assembly via Unity. Then right click on it and select "Use howl".

## How do I delete an assembly definition?

If your assembly definition is in the build dir, do not delete the assembly. Instead, delete its Howl counterpart. If your assembly is `super.asmdef`, the counterpart is named `super.asmdt`
