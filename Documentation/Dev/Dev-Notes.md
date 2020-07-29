# Developer notes

## Changing the symset

After changing the symset, do this:

- Run all tests
- Inject the symset
- Make Snippets

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
