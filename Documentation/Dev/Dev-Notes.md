# Developer notes

## Enable developer mode

A utility window is needed to inject the tree-sitter grammar template; to bring it up add `-define:DEV_MODE` to `Assets/csc.rsp` and recompile. The window is under *Activ > Howl utils*

## Changing the symset

After changing the symset, do this:

- Run all tests
- Run 'Inject Grammar Template' via Howl utils
- Make Snippets

Then:

```sh
cd ~/Documents/tree-sitter-howl
tree-sitter generate && tree-sitter parse ex.howl
git add --all
git commit ...
npm version x.x.x
npm publish
cd ~/.atom/packages/language-howl
git add --all
git commit ...
apm install
# reload atom window to ensure all okay
```
