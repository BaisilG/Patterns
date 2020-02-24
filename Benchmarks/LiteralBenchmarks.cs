﻿using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier.Patterns;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class LiteralBenchmarks {
		public static readonly Regex msregex = new Regex("^Hello");

		public static readonly Regex msregexCompiled = new Regex("^Hello", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^Hello");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^Hello", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Parser.String("Hello");

		public static readonly Sprache.Parser<String> sprache = Parse.String("Hello").Text();

		public static readonly Pattern stringier = "Hello";

		[Params("Hello", "World", "H", "Failure")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public Match MSRegexCompiled() => msregexCompiled.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegex() => pcreregex.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegexCompiled() => pcreregexCompiled.Match(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public String Sprache() => sprache.Parse(Source);

		[Benchmark]
		public Stringier.Patterns.Result Stringier() => stringier.Consume(Source);
	}
}
