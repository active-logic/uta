# Cosmo Specification
v0.2.9α - © T.E.A de Souza 2020, All Rights Reserved.

Cosmo is an expressive notation drawing from natural scripts(*),
symbolic formalisms and dingbats.

### Header
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 1 | ⊐ | using |  |

### Blocks
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 2 | ⊓ | namespace |  |
| 3 | ○ | class |  |
| 4 | ⍧ | delegate |  |
| 5 | ⍥ | enum |  |
| 6 | ◌ | interface |  |
| 7 | ⊟ | struct |  |

### Modifiers
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 8 | ‒ | public |  |
| 9 | ◠ | protected |  |
| 10 | ╌ | internal |  |
| 11 | ▰ | private |  |
| 12 | ☋ | abstract |  |
| 13 | ᴸ | const |  |
| 14 | ⁺ | override |  |
| 15 | ᴾ | partial |  |
| 16 | ⌷ | readonly |  |
| 17 | ∘ | static |  |
| 18 | ᵛ | virtual |  |
| 19 | 🔒 | sealed  |  |

### Control flow
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 20 | ⤴ | if |  |
| 21 | ⤵ | else |  |
| 22 | ⤳ | else if |  |
| 23 | ∀ | foreach |  |
| 24 | ∈ | in |  |
| 25 | ⟳ | for |  |
| 26 | ⟲ | while |  |
| 27 | ⤓ | continue; |  |
| 28 | ⤭ | switch |  |
| 29 | ⥰ | case |  |
| 30 | ¦ | break; |  |
| 31 | ⮐ | return |  |
| 32 | ↯ | try |  |
| 33 | ⇤ | catch |  |
| 34 | (╯°□°)╯ | throw |  |
| 35 | (˙▿˙) | finally |  |

### Linq
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 36 | ‖ | from |  |
| 37 | ¿ | where |  |
| 38 | ፥ | select |  |
| 39 | ⏢ | orderby |  |
| 40 | ◿ | ascending |  |
| 41 | ◺ | descending |  |

### Operators
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 42 | → | => | as (→) |
| 43 | ☰ | == | equals (☰) |
| 44 | ≠ | != | unequals (≠) |
| 45 | ≥ | >= | greater or equals (≥) |
| 46 | ≤ | <= | lesser or equals (≤) |
| 47 | ∧ | && | and (∧) |
| 48 | ∨ | || | or (∨) |
| 49 | ⨕ | operator | Overloading operator |
| 50 | ⒠ | public static explicit operator | Explicit type conversion |
| 51 | ⒤ | public static implicit operator | Implicit type conversion |

### Primitives
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 52 | ㅇ | bool |  |
| 53 | ᆨ | byte |  |
| 54 | ᆩ | char |  |
| 55 | ᅮ | short |  |
| 56 | ᆞ | int |  |
| 57 | ᅭ | long |  |
| 58 | ㅅ | float |  |
| 59 | ㅆ | double |  |
| 60 | ᄍ | decimal |  |
| 61 | ㄹ | string |  |
| 62 | ⊡ | object |  |
| 63 | ∙ | var |  |

### Keywords
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 64 | ╭ | get |  |
| 65 | ╰ | set |  |
| 66 | ✓ | true |  |
| 67 | ✗ | false |  |
| 68 | ⌢ | new |  |
| 69 | ∅ | null |  |
| 70 | ⦿ | this |  |
| 71 | ┈ | void |  |
| 72 | ⋯ | params |  |

### Semantics
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 73 | ⒜ | Action | Action pointer |
| 74 | ⒡ | Func | Function pointer |
| 75 | 𝕄 | Dictionary | Map type |
| 76 | 𝕊 | HashSet | Set type |
| 77 | 𝔼 | IEnumerator | Enumerable collection type |
| 78 | 𝕃 | List |  |
| 79 | √ | Sqrt |  |
| 80 | ∑ | Sum |  |
| 81 | 𝛑 | pi (3.14...) |  |
| 82 | ± | Append |  |
| 83 | ∋ | Contains |  |
| 84 | ⋺ | ContainsKey |  |
| 85 | ∃ | Exists |  |
| 86 | ⧕ | that |  |

### Idioms
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 87 | ⎚ | () => | Action reference |
| 88 | ⁝ | .Count |  |
| 89 | ❙ | .Length |  |
| 90 | 🝠 | .ToString() |  |
| 91 | ৴ | .ToArray() |  |
| 92 | ᖾ | .Value |  |
| 93 | 【 | (this, |  |

### NUnit
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 94 | ؟ | [Test] public void | Test case |
| 95 | ⍜ | [SetUp] public void | Fixture setup |
| 96 | ⍉ | [TearDown] public void | Fixture teardown |
| 97 | ಠᴗಠ | Assert.Throws |  |

### Unity
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 98 | ロ | GameObject |  |
| 99 | ⫙ | Component |  |
| 100 | エ | Transform |  |
| 101 | ᇅ | Quaternion |  |
| 102 | フ | Vector2 |  |
| 103 | シ | Vector3 |  |
| 104 | タ | Vector4 |  |
| 105 | ト | Vector2 | Point2 |
| 106 | メ | Vector3 | Point3 |
| 107 | メ̂ | Vector4 | Point4 |
| 108 | 《 | gameObject.AddComponent< | AddComponent |
| 109 | ⧼ | GetComponent< | GetComponent |
| 110 | ⏚ | [UnityTest] public IEnumerator | Asynchronous test |
| 111 | ⏰ | yield return new WaitForSeconds | Synchronous timer |

### Active Logic
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 112 | ⑂ | status |  |
| 113 | ◇ | done() | Complete task status |
| 114 | ☡ | cont() | Ongoing task status |
| 115 | ■ | fail() | Failing task status |
| 116 | ⌽ | return @void(); | Void token |
