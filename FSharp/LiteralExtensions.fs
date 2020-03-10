﻿namespace Stringier.Patterns

open System
open System.Text

[<AutoOpen>]
module LiteralExtensions =
    
    type Binder =
        static member Literal(value:String) = value.AsPattern()
        static member Literal(value:Char) = value.AsPattern()
        static member Literal(value:Rune) = value.AsPattern()
        static member Literal(value:Capture ref) = (!value).AsPattern()
        static member Literal(value:System.Text.RegularExpressions.Regex) = value.AsPattern()
        static member With(pattern:String, comparisonType:Compare) = pattern.With(comparisonType)
        static member With(pattern:Char, comparisonType:Compare) = pattern.With(comparisonType)
        static member With(pattern:Rune, comparisonType:Compare) = pattern.With(comparisonType)
        static member With(pattern:Capture ref, comparisonType:Compare) = (!pattern).With(comparisonType)

    let inline private literal< ^t, ^a, ^b when (^t or ^a) : (static member Literal : ^a -> ^b)> value = ((^t or ^a) : (static member Literal : ^a -> ^b)(value))

    let inline private _with< ^t, ^a, ^b, ^c when (^t or ^a) : (static member With : ^a * ^b -> ^c)> pattern add = ((^t or ^a) : (static member With : ^a * ^b -> ^c)(pattern, add))

    /// <summary>
    /// Marks the specified value as being a <see cref="Pattern" />.
    /// </summary>
    let inline p value = literal<Binder, _, Pattern> value

    let inline ( /= ) pattern add = _with<Binder, _, _, Pattern> pattern add