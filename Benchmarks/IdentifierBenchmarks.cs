﻿using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier;
using Stringier.Patterns;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class IdentifierBenchmarks {
		public static readonly Regex msregex = new Regex("^\\w(?:\\w|_)+");

		public static readonly Regex msregexCompiled = new Regex("^\\w(?:\\w|_)+", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^\\w(?:\\w|_)+");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^\\w(?:\\w|_)+", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Parser.Letter.Then(Parser.Letter.Or(Parser.Char('_')).ManyString());

		public static readonly Sprache.Parser<String> sprache = Parse.Letter.Then(_ => Parse.Letter.Or(Parse.Char('_')).Many().Text());

		public static readonly Pattern stringier = Pattern.Check(
			(Char) => Char.IsLetter(), true,
			(Char) => Char.IsLetter() || Char == '_', true,
			(Char) => Char.IsLetter() || Char == '_', false);

		[Params("Hello_World")]
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
