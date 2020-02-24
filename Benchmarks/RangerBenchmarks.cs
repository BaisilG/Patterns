﻿using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using static Pidgin.Parser;
using Stringier.Patterns;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class RangerBenchmarks {

		public static readonly Regex msregex = new Regex("^Hello.*;$");

		public static readonly Regex msregexCompiled = new Regex("^Hello.*;$", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^Hello.*;$");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^Hello.*;$", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Map((start, between, end) => start + between + end, String("Hello"), Not(Char(';')), Char(';'));

		public static readonly Pattern stringier = Pattern.Range("Hello", ";");

		[Params("Hello World;", "Hello World", "Goodbye World;")]
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
		public Result Stringier() => stringier.Consume(Source);
	}
}
