# Cosmo Specification
v0.2.10α - © T.E.A de Souza 2020, All Rights Reserved.

An expressive notation drawing from natural scripts,
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
| 27 | 〰 | continue; |  |
| 28 | ⤭ | switch |  |
| 29 | ⥰ | case |  |
| 30 | ¦ | break; |  |
| 31 | ⮐ | return |  |
| 32 | ↯ | try |  |
| 33 | ⇤ | catch |  |
| 34 | (╯°□°)╯ | throw |  |
| 35 | (˙▿˙) | finally |  |
| 36 | ㆑ | return true; |  |
| 37 | ⤬ | return false; |  |

### Linq
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 38 | ‖ | from |  |
| 39 | ¿ | where |  |
| 40 | ፥ | select |  |
| 41 | ⏢ | orderby |  |
| 42 | ◿ | ascending |  |
| 43 | ◺ | descending |  |

### Operators
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 44 | → | => | as (→) |
| 45 | ☰ | == | equals (☰) |
| 46 | ≠ | != | unequals (≠) |
| 47 | ≥ | >= | greater or equals (≥) |
| 48 | ≤ | <= | lesser or equals (≤) |
| 49 | ∧ | && | and (∧) |
| 50 | ∨ | || | or (∨) |
| 51 | ⨕ | operator | Overloading operator |
| 52 | ⒠ | public static explicit operator | Explicit type conversion |
| 53 | ⒤ | public static implicit operator | Implicit type conversion |

### Primitives
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 54 | ㅇ | bool |  |
| 55 | ᆨ | byte |  |
| 56 | ᆩ | char |  |
| 57 | ᅮ | short |  |
| 58 | ᆞ | int |  |
| 59 | ᅭ | long |  |
| 60 | ㅅ | float |  |
| 61 | ㅆ | double |  |
| 62 | ᄍ | decimal |  |
| 63 | ㄹ | string |  |
| 64 | ⊡ | object |  |
| 65 | ∙ | var |  |

### Keywords
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 66 | ╭ | get |  |
| 67 | ╰ | set |  |
| 68 | ✓ | true |  |
| 69 | ✗ | false |  |
| 70 | ⌢ | new |  |
| 71 | ∅ | null |  |
| 72 | ⦿ | this |  |
| 73 | ┈ | void |  |
| 74 | ⋯ | params |  |

### Semantics
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 75 | ⒜ | Action | Action pointer |
| 76 | ⒡ | Func | Function pointer |
| 77 | 𝕄 | Dictionary | Map type |
| 78 | 𝕊 | HashSet | Set type |
| 79 | 𝔼 | IEnumerator | Enumerable collection type |
| 80 | 𝕃 | List |  |
| 81 | √ | Sqrt | Square root |
| 82 | ∑ | Sum |  |
| 83 | 𝛑 | pi (3.14...) |  |
| 84 | ± | Append |  |
| 85 | ∋ | Contains |  |
| 86 | ⋺ | ContainsKey |  |
| 87 | ∃ | Exists |  |
| 88 | ⧕ | that |  |

### Idioms
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 89 | ⎚ | () => | Action reference |
| 90 | ⁝ | .Count |  |
| 91 | ❙ | .Length |  |
| 92 | 🝠 | .ToString() |  |
| 93 | ৴ | .ToArray() |  |
| 94 | ᖾ | .Value |  |
| 95 | 【 | (this, |  |

### NUnit
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 96 | ؟ | [Test] public void | Test case |
| 97 | ⍜ | [SetUp] public void | Fixture setup |
| 98 | ⍉ | [TearDown] public void | Fixture teardown |
| 99 | ಠᴗಠ | Assert.Throws |  |

### Unity
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 100 | ロ | GameObject |  |
| 101 | ⫙ | Component |  |
| 102 | エ | Transform |  |
| 103 | ᇅ | Quaternion |  |
| 104 | フ | Vector2 |  |
| 105 | シ | Vector3 |  |
| 106 | タ | Vector4 |  |
| 107 | ト | Vector2 | Point2 |
| 108 | メ | Vector3 | Point3 |
| 109 | メ̂ | Vector4 | Point4 |
| 110 | 《 | gameObject.AddComponent< | AddComponent |
| 111 | ⧼ | GetComponent< | GetComponent |
| 112 | ⏚ | [UnityTest] public IEnumerator | Asynchronous test |
| 113 | ⏰ | yield return new WaitForSeconds | Synchronous timer |

### Active Logic
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 114 | ⑂ | status |  |
| 115 | ◇ | done() | Complete task status |
| 116 | ☡ | cont() | Ongoing task status |
| 117 | ■ | fail() | Failing task status |
| 118 | ⌽ | return @void(); | Void token |
