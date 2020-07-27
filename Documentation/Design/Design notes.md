# Howl design notes

## Types and other containers

Keywords: class, interface, namespace, struct

⊓ namespace
○ class
◌ interface
⊟ Struct

## Modifiers

Preferably we would have all modifiers combined as a unique symbol; the main glyph represents an access modifier.

```                 
                    Sym.    Name
public              ‒       Figure dash
protected           ◠       Upper half circle
internal            ╌       Double dash
protected internal  ╍       Heavy double dash
private             ▰       Black parallelogram
```

A ring under the modifier indicates static access.


Considered alternatives included:
- Coloring (vary color to indicate access)
- Geometric shapes (circle, square, lozenge)

*Keywords*
dash, horizontal, bar, circle, square, box, black

A base symbol is declined using combining symbols and side-scripts.

TODO:
- Combined forms should not appear in the selector
