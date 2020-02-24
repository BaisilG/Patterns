﻿namespace Patterns

open System
open Stringier
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CheckerTests() =

    [<TestMethod>]
    member _.``StringChecker consume`` () =
        //! This is a sophisticated, therefore fragile, pattern type. It needs to be exhaustively tested against a very large battery. Do not remove these no matter how redundant they may seem, for they are not.
        let mutable pattern = Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), true,
                                            (fun (char:char) -> char.IsLetterOrDigit() || char = '-' || char = '_'), true,
                                            (fun (char:char) -> char.IsLetterOrDigit()), true)
        ResultAssert.Fails(pattern.Consume("a"))
        ResultAssert.Fails(pattern.Consume("a "))
        ResultAssert.Fails(pattern.Consume("aa"))
        ResultAssert.Fails(pattern.Consume("aa "))
        ResultAssert.Fails(pattern.Consume("_a"))
        ResultAssert.Fails(pattern.Consume("_a "))
        ResultAssert.Fails(pattern.Consume("a_"))
        ResultAssert.Fails(pattern.Consume("a_ "))
        ResultAssert.Fails(pattern.Consume("1b"))
        ResultAssert.Fails(pattern.Consume("1b "))
        ResultAssert.Fails(pattern.Consume("a2"))
        ResultAssert.Fails(pattern.Consume("a2 "))
        ResultAssert.Fails(pattern.Consume("12"))
        ResultAssert.Fails(pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Fails(pattern.Consume("ab_"))
        ResultAssert.Fails(pattern.Consume("ab_ "))
        ResultAssert.Fails(pattern.Consume("-bc"))
        ResultAssert.Fails(pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Fails(pattern.Consume("ab-"))
        ResultAssert.Fails(pattern.Consume("ab- "))
        ResultAssert.Fails(pattern.Consume("1bc"))
        ResultAssert.Fails(pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Fails(pattern.Consume("123"))
        ResultAssert.Fails(pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))

        pattern <- Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), false,
                                 (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), true,
                                 (fun (char:char) -> char.IsLetterOrDigit()), true)
        ResultAssert.Fails(pattern.Consume("a"))
        ResultAssert.Fails(pattern.Consume("a "))
        ResultAssert.Captures("aa", pattern.Consume("aa"))
        ResultAssert.Captures("aa", pattern.Consume("aa "))
        ResultAssert.Captures("_a", pattern.Consume("_a"))
        ResultAssert.Captures("_a", pattern.Consume("_a "))
        ResultAssert.Fails(pattern.Consume("a_"))
        ResultAssert.Fails(pattern.Consume("a_ "))
        ResultAssert.Captures("1b", pattern.Consume("1b"))
        ResultAssert.Captures("1b", pattern.Consume("1b "))
        ResultAssert.Captures("a2", pattern.Consume("a2"))
        ResultAssert.Captures("a2", pattern.Consume("a2 "))
        ResultAssert.Captures("12", pattern.Consume("12"))
        ResultAssert.Captures("12", pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Fails(pattern.Consume("ab_"))
        ResultAssert.Fails(pattern.Consume("ab_ "))
        ResultAssert.Captures("-bc", pattern.Consume("-bc"))
        ResultAssert.Captures("-bc", pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Fails(pattern.Consume("ab-"))
        ResultAssert.Fails(pattern.Consume("ab- "))
        ResultAssert.Captures("1bc", pattern.Consume("1bc"))
        ResultAssert.Captures("1bc", pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Captures("123", pattern.Consume("123"))
        ResultAssert.Captures("123", pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))
        
        pattern <- Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), true,
                                 (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), false,
                                 (fun (char:char) -> char.IsLetterOrDigit()), true)
        ResultAssert.Fails(pattern.Consume("a"))
        ResultAssert.Fails(pattern.Consume("a "))
        ResultAssert.Captures("aa", pattern.Consume("aa"))
        ResultAssert.Captures("aa", pattern.Consume("aa "))
        ResultAssert.Captures("_a", pattern.Consume("_a"))
        ResultAssert.Captures("_a", pattern.Consume("_a "))
        ResultAssert.Fails(pattern.Consume("a_"))
        ResultAssert.Fails(pattern.Consume("a_ "))
        ResultAssert.Fails(pattern.Consume("1b"))
        ResultAssert.Fails(pattern.Consume("1b "))
        ResultAssert.Captures("a2", pattern.Consume("a2"))
        ResultAssert.Captures("a2", pattern.Consume("a2 "))
        ResultAssert.Fails(pattern.Consume("12"))
        ResultAssert.Fails(pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Fails(pattern.Consume("ab_"))
        ResultAssert.Fails(pattern.Consume("ab_ "))
        ResultAssert.Fails(pattern.Consume("-bc"))
        ResultAssert.Fails(pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Fails(pattern.Consume("ab-"))
        ResultAssert.Fails(pattern.Consume("ab- "))
        ResultAssert.Fails(pattern.Consume("1bc"))
        ResultAssert.Fails(pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Fails(pattern.Consume("123"))
        ResultAssert.Fails(pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))
        
        pattern <- Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), true,
                                 (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), true,
                                 (fun (char:char) -> char.IsLetterOrDigit()), false)
        ResultAssert.Fails(pattern.Consume("a"))
        ResultAssert.Fails(pattern.Consume("a "))
        ResultAssert.Captures("aa", pattern.Consume("aa"))
        ResultAssert.Captures("aa", pattern.Consume("aa "))
        ResultAssert.Captures("_a", pattern.Consume("_a"))
        ResultAssert.Captures("_a", pattern.Consume("_a "))
        ResultAssert.Captures("a_", pattern.Consume("a_"))
        ResultAssert.Captures("a_", pattern.Consume("a_ "))
        ResultAssert.Fails(pattern.Consume("1b"))
        ResultAssert.Fails(pattern.Consume("1b "))
        ResultAssert.Captures("a2", pattern.Consume("a2"))
        ResultAssert.Captures("a2", pattern.Consume("a2 "))
        ResultAssert.Fails(pattern.Consume("12"))
        ResultAssert.Fails(pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Captures("ab_", pattern.Consume("ab_"))
        ResultAssert.Captures("ab_", pattern.Consume("ab_ "))
        ResultAssert.Fails(pattern.Consume("-bc"))
        ResultAssert.Fails(pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Captures("ab-", pattern.Consume("ab-"))
        ResultAssert.Captures("ab-", pattern.Consume("ab- "))
        ResultAssert.Fails(pattern.Consume("1bc"))
        ResultAssert.Fails(pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Fails(pattern.Consume("123"))
        ResultAssert.Fails(pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))
        
        pattern <- Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), false,
                                 (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), false,
                                 (fun (char:char) -> char.IsLetterOrDigit()), true)
        ResultAssert.Captures("a", pattern.Consume("a"))
        ResultAssert.Captures("a", pattern.Consume("a "))
        ResultAssert.Captures("1", pattern.Consume("1"))
        ResultAssert.Captures("1", pattern.Consume("1 "))
        ResultAssert.Captures("aa", pattern.Consume("aa"))
        ResultAssert.Captures("aa", pattern.Consume("aa "))
        ResultAssert.Captures("_a", pattern.Consume("_a"))
        ResultAssert.Captures("_a", pattern.Consume("_a "))
        ResultAssert.Fails(pattern.Consume("a_"))
        ResultAssert.Fails(pattern.Consume("a_ "))
        ResultAssert.Captures("1b", pattern.Consume("1b"))
        ResultAssert.Captures("1b", pattern.Consume("1b "))
        ResultAssert.Captures("a2", pattern.Consume("a2"))
        ResultAssert.Captures("a2", pattern.Consume("a2 "))
        ResultAssert.Captures("12", pattern.Consume("12"))
        ResultAssert.Captures("12", pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Fails(pattern.Consume("ab_"))
        ResultAssert.Fails(pattern.Consume("ab_ "))
        ResultAssert.Captures("-bc", pattern.Consume("-bc"))
        ResultAssert.Captures("-bc", pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Fails(pattern.Consume("ab-"))
        ResultAssert.Fails(pattern.Consume("ab- "))
        ResultAssert.Captures("1bc", pattern.Consume("1bc"))
        ResultAssert.Captures("1bc", pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Captures("123", pattern.Consume("123"))
        ResultAssert.Captures("123", pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))
        
        pattern <- Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), false,
                                 (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), true,
                                 (fun (char:char) -> char.IsLetterOrDigit()), false)
        ResultAssert.Captures("a", pattern.Consume("a"))
        ResultAssert.Captures("a", pattern.Consume("a "))
        ResultAssert.Captures("1", pattern.Consume("1"))
        ResultAssert.Captures("1", pattern.Consume("1 "))
        ResultAssert.Captures("aa", pattern.Consume("aa"))
        ResultAssert.Captures("aa", pattern.Consume("aa "))
        ResultAssert.Captures("_a", pattern.Consume("_a"))
        ResultAssert.Captures("_a", pattern.Consume("_a "))
        ResultAssert.Captures("a_", pattern.Consume("a_"))
        ResultAssert.Captures("a_", pattern.Consume("a_ "))
        ResultAssert.Captures("1b", pattern.Consume("1b"))
        ResultAssert.Captures("1b", pattern.Consume("1b "))
        ResultAssert.Captures("a2", pattern.Consume("a2"))
        ResultAssert.Captures("a2", pattern.Consume("a2 "))
        ResultAssert.Captures("12", pattern.Consume("12"))
        ResultAssert.Captures("12", pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Captures("ab_", pattern.Consume("ab_"))
        ResultAssert.Captures("ab_", pattern.Consume("ab_ "))
        ResultAssert.Captures("-bc", pattern.Consume("-bc"))
        ResultAssert.Captures("-bc", pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Captures("ab-", pattern.Consume("ab-"))
        ResultAssert.Captures("ab-", pattern.Consume("ab- "))
        ResultAssert.Captures("1bc", pattern.Consume("1bc"))
        ResultAssert.Captures("1bc", pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Captures("123", pattern.Consume("123"))
        ResultAssert.Captures("123", pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))
        
        pattern <- Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), true,
                                 (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), false,
                                 (fun (char:char) -> char.IsLetterOrDigit()), false)
        ResultAssert.Captures("a", pattern.Consume("a"))
        ResultAssert.Captures("a", pattern.Consume("a "))
        ResultAssert.Fails(pattern.Consume("1"))
        ResultAssert.Fails(pattern.Consume("1 "))
        ResultAssert.Captures("aa", pattern.Consume("aa"))
        ResultAssert.Captures("aa", pattern.Consume("aa "))
        ResultAssert.Captures("_a", pattern.Consume("_a"))
        ResultAssert.Captures("_a", pattern.Consume("_a "))
        ResultAssert.Captures("a_", pattern.Consume("a_"))
        ResultAssert.Captures("a_", pattern.Consume("a_ "))
        ResultAssert.Fails(pattern.Consume("1b"))
        ResultAssert.Fails(pattern.Consume("1b "))
        ResultAssert.Captures("a2", pattern.Consume("a2"))
        ResultAssert.Captures("a2", pattern.Consume("a2 "))
        ResultAssert.Fails(pattern.Consume("12"))
        ResultAssert.Fails(pattern.Consume("12 "))
        ResultAssert.Captures("abc", pattern.Consume("abc"))
        ResultAssert.Captures("abc", pattern.Consume("abc "))
        ResultAssert.Captures("_bc", pattern.Consume("_bc"))
        ResultAssert.Captures("_bc", pattern.Consume("_bc "))
        ResultAssert.Captures("a_c", pattern.Consume("a_c"))
        ResultAssert.Captures("a_c", pattern.Consume("a_c "))
        ResultAssert.Captures("ab_", pattern.Consume("ab_"))
        ResultAssert.Captures("ab_", pattern.Consume("ab_ "))
        ResultAssert.Fails(pattern.Consume("-bc"))
        ResultAssert.Fails(pattern.Consume("-bc "))
        ResultAssert.Captures("a-c", pattern.Consume("a-c"))
        ResultAssert.Captures("a-c", pattern.Consume("a-c "))
        ResultAssert.Captures("ab-", pattern.Consume("ab-"))
        ResultAssert.Captures("ab-", pattern.Consume("ab- "))
        ResultAssert.Fails(pattern.Consume("1bc"))
        ResultAssert.Fails(pattern.Consume("1bc "))
        ResultAssert.Captures("a2c", pattern.Consume("a2c"))
        ResultAssert.Captures("a2c", pattern.Consume("a2c "))
        ResultAssert.Captures("ab3", pattern.Consume("ab3"))
        ResultAssert.Captures("ab3", pattern.Consume("ab3 "))
        ResultAssert.Captures("a23", pattern.Consume("a23"))
        ResultAssert.Captures("a23", pattern.Consume("a23 "))
        ResultAssert.Fails(pattern.Consume("123"))
        ResultAssert.Fails(pattern.Consume("123 "))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde"))
        ResultAssert.Captures("a_cde", pattern.Consume("a_cde "))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de"))
        ResultAssert.Captures("ab_de", pattern.Consume("ab_de "))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e"))
        ResultAssert.Captures("abc_e", pattern.Consume("abc_e "))
        ResultAssert.Captures("a__de", pattern.Consume("a__de"))
        ResultAssert.Captures("a__de", pattern.Consume("a__de "))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e"))
        ResultAssert.Captures("ab__e", pattern.Consume("ab__e "))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e"))
        ResultAssert.Captures("a_c_e", pattern.Consume("a_c_e "))
        ResultAssert.Captures("a___e", pattern.Consume("a___e"))
        ResultAssert.Captures("a___e", pattern.Consume("a___e "))
        
        Assert.ThrowsException<PatternConstructionException>(Action (fun () -> Pattern.Check((fun (char:char) -> char.IsLetter() || char = '_'), false,
                                                                                             (fun (char:char) -> char.IsLetterOrDigit() || char = '_' || char = '-'), false,
                                                                                             (fun (char:char) -> char.IsLetterOrDigit()), false) |> ignore)) |> ignore
        
    [<TestMethod>]
    member _.``WordChecker consume`` () =
        let mutable pattern = Pattern.Check(Bias.Head,
                                           (fun (char:char) -> char = '_'),
                                           (fun (char:char) -> char.IsLetter()),
                                           (fun (char:char) -> char.IsLetterOrDigit()))
        ResultAssert.Captures("_", pattern.Consume("_"))
        ResultAssert.Captures("_", pattern.Consume("_ "))
        ResultAssert.Fails(pattern.Consume("b"))
        ResultAssert.Fails(pattern.Consume("b "))
        ResultAssert.Fails(pattern.Consume("3"))
        ResultAssert.Fails(pattern.Consume("3 "))
        ResultAssert.Captures("_3", pattern.Consume("_3"))
        ResultAssert.Captures("_3", pattern.Consume("_3 "))
        ResultAssert.Captures("_b3", pattern.Consume("_b3"))
        ResultAssert.Captures("_b3", pattern.Consume("_b3 "))
        ResultAssert.Captures("_example", pattern.Consume("_example"))
        ResultAssert.Captures("_example", pattern.Consume("_example "))
        ResultAssert.Captures("_example3", pattern.Consume("_example3"))
        ResultAssert.Captures("_example3", pattern.Consume("_example3 "))
        ResultAssert.Captures("_example", pattern.Consume("_example_"))
        ResultAssert.Captures("_example", pattern.Consume("_example_ "))
        
        pattern <- Pattern.Check(Bias.Tail,
                                (fun (char:char) -> char = '_'),
                                (fun (char:char) -> char.IsLetter()),
                                (fun (char:char) -> char.IsLetterOrDigit()))
        ResultAssert.Fails(pattern.Consume("_"))
        ResultAssert.Fails(pattern.Consume("_ "))
        ResultAssert.Captures("b", pattern.Consume("b"))
        ResultAssert.Captures("b", pattern.Consume("b "))
        ResultAssert.Captures("3", pattern.Consume("3"))
        ResultAssert.Captures("3", pattern.Consume("3 "))
        ResultAssert.Captures("_3", pattern.Consume("_3"))
        ResultAssert.Captures("_3", pattern.Consume("_3 "))
        ResultAssert.Captures("_b3", pattern.Consume("_b3"))
        ResultAssert.Captures("_b3", pattern.Consume("_b3 "))
        ResultAssert.Captures("_example", pattern.Consume("_example"))
        ResultAssert.Captures("_example", pattern.Consume("_example "))
        ResultAssert.Captures("_example3", pattern.Consume("_example3"))
        ResultAssert.Captures("_example3", pattern.Consume("_example3 "))
        ResultAssert.Captures("_example", pattern.Consume("_example_"))
        ResultAssert.Captures("_example", pattern.Consume("_example_ "))
