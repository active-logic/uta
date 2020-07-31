# About Git and Version Control

## What is Git, and what is version control?

A version control system keeps your code (and other assets) safe by generating backups and a file history. Compared to just "doing a backup" version control has a learning curve.


Also it is, overall *better*.

## Why do I need version control to use Howl?

You do not. Howl, however, is not mature software. In order to protect your files in case anything happens, I strongly recommend you use VCS.


When Howl exits beta, this requirement will be lifted (though I still recommend you use Git anyways, and not aware of a practical alternative for small/medium sized projects).

## So how does it work?

Open a terminal window and cd to your project directory; then type the following:

```sh
git init
git add --all
git commit -m "Initial commit"
```

Once you are done with this, you can start using Howl in Unity3D.

When you are done with whatever task you were doing, once again cd to your project directory; then create a "save point" like so:

```sh
git add --all
git commit -m "Added option to switch weapon"
```

There are great tools like *SourceTree* which can help you do this without using the terminal/command line. In fact there is a super-abundance of git related tutorials and resources online. My goal here is not to teach you how.

## I still don't want to use Git!

If it's down to that, create a file named `.git` in your project directory. This will fool the Howl/Unity integration.

Remember:
- Once you start editing Howl sources, they will overwrite your C# scripts.
- Howl comes with **no warrantee**
