﻿namespace Stringier.Patterns

[<AutoOpen>]
module UniqueExtensions =

    let inline kleene pattern = maybe(many(pattern))

    let inline seal (pattern:Pattern) =
        pattern.Seal()
        pattern