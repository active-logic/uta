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
| 4 | 𐋆 | delegate |  |
| 5 | ⍥ | enum |  |
| 6 | 𐋂 | interface |  |
| 7 | ⊟ | struct |  |

### Modifiers
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 8 | ‒ | public |  |
| 9 | ◠ | protected |  |
| 10 | ︲ | internal |  |
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
| 30 | ～ | default |  |
| 31 | ¦ | break; |  |
| 32 | ⤏ | when |  |
| 33 | ⮐ | return |  |
| 34 | ↯ | try |  |
| 35 | ⇤ | catch |  |
| 36 | (╯°□°)╯ | throw |  |
| 37 | (˙▿˙) | finally |  |
| 38 | ㆑ | return true; |  |
| 39 | ⤬ | return false; |  |

### Linq
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 40 | ‖ | from |  |
| 41 | ¿ | where |  |
| 42 | ፥ | select |  |
| 43 | ⏢ | orderby |  |
| 44 | ◿ | ascending |  |
| 45 | ◺ | descending |  |

### Operators
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 46 | → | => | as (→) |
| 47 | ☰ | == | equals (☰) |
| 48 | ≠ | != | unequals (≠) |
| 49 | ≥ | >= | greater or equals (≥) |
| 50 | ≤ | <= | lesser or equals (≤) |
| 51 | ∧ | && | and (∧) |
| 52 | ∨ | || | or (∨) |
| 53 | ⨕ | operator | Overloading operator |
| 54 | ⒠ | public static explicit operator | Explicit type conversion |
| 55 | ⒤ | public static implicit operator | Implicit type conversion |

### Primitives
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 56 | ㅇ | bool |  |
| 57 | ᆨ | byte |  |
| 58 | ᆩ | char |  |
| 59 | ᅮ | short |  |
| 60 | ᆞ | int |  |
| 61 | ᅭ | long |  |
| 62 | ㅅ | float |  |
| 63 | ㅆ | double |  |
| 64 | ᄍ | decimal |  |
| 65 | ㄹ | string |  |
| 66 | ⊡ | object |  |
| 67 | ∙ | var |  |

### Keywords
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 68 | ╭ | get |  |
| 69 | ╰ | set |  |
| 70 | ✓ | true |  |
| 71 | ✗ | false |  |
| 72 | ⌢ | new |  |
| 73 | ∅ | null |  |
| 74 | ⦿ | this |  |
| 75 | ┈ | void |  |
| 76 | ⋯ | params |  |

### Semantics
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 77 | ⒜ | Action | Action pointer |
| 78 | ⒡ | Func | Function pointer |
| 79 | 𝕄 | Dictionary | Map type |
| 80 | 𝕊 | HashSet | Set type |
| 81 | 𝔼 | IEnumerator | Enumerable collection type |
| 82 | 𝕃 | List |  |
| 83 | √ | Sqrt | Square root |
| 84 | ∑ | Sum |  |
| 85 | 𝛑 | pi (3.14...) |  |
| 86 | ± | Append |  |
| 87 | ∋ | Contains |  |
| 88 | ⋺ | ContainsKey |  |
| 89 | ∃ | Exists |  |
| 90 | ⧕ | that |  |

### Idioms
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 91 | ⎚ | () => | Action reference |
| 92 | ⁝ | .Count |  |
| 93 | ❙ | .Length |  |
| 94 | 🝠 | .ToString() |  |
| 95 | ৴ | .ToArray() |  |
| 96 | ᖾ | .Value |  |
| 97 | 【 | (this, |  |

### NUnit
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 98 | ؟ | [Test] public void | Test case |
| 99 | ⍜ | [SetUp] public void | Fixture setup |
| 100 | ⍉ | [TearDown] public void | Fixture teardown |
| 101 | ಠᴗಠ | Assert.Throws |  |

### Unity
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 102 | ロ | GameObject |  |
| 103 | ⫙ | Component |  |
| 104 | エ | Transform |  |
| 105 | ᇅ | Quaternion |  |
| 106 | フ | Vector2 |  |
| 107 | シ | Vector3 |  |
| 108 | タ | Vector4 |  |
| 109 | ト | Vector2 | Point2 |
| 110 | メ | Vector3 | Point3 |
| 111 | メ̂ | Vector4 | Point4 |
| 112 | 《 | gameObject.AddComponent< | AddComponent |
| 113 | ⧼ | GetComponent< | GetComponent |
| 114 | ⏚ | [UnityTest] public IEnumerator | Asynchronous test |
| 115 | ⏰ | yield return new WaitForSeconds | Synchronous timer |

### Active Logic
|  #  | Sym | Syntax    | Description |
| :-: | :-: | ---       | ---         |
| 116 | ⑂ | status |  |
| 117 | ◇ | done() | Complete task status |
| 118 | ☡ | cont() | Ongoing task status |
| 119 | ■ | fail() | Failing task status |
| 120 | ⌽ | return @void(); | Void token |
