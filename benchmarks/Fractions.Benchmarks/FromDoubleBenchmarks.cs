﻿#pragma warning disable CA1822

using BenchmarkDotNet.Attributes;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
public class FromDoubleBenchmarks {
    public FromDoubleBenchmarks() {
        // initialize static
        _ = Fraction.Zero;
    }
    
    public static IEnumerable<double> DoubleValues => [
        0, double.NaN, double.PositiveInfinity, double.NegativeInfinity,
        42,
        1.345,
        1.0/3,
        -37*10e-8,
        1024*10e8,
        2110.11170524,
        0.022046226218487758,
        5.9722E+24,
        -1.0/37,
        (0.001 / 1e3) * 100000,
        (double)decimal.MinValue,
        double.MaxValue,
        Math.PI
    ];

    [Benchmark]
    [ArgumentsSource(nameof(DoubleValues))]
    public Fraction Construct_FromDouble(double value) {
        return Fraction.FromDouble(value);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DoubleValues))]
    public Fraction Construct_FromDoubleRounded(double value) {
        return Fraction.FromDoubleRounded(value);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DoubleValues))]
    public Fraction Construct_FromDoubleRoundedToFifteenDigits(double value) {
        return Fraction.FromDoubleRounded(value, 15);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DoubleValues))]
    public Fraction Construct_FromDoubleRoundedToEighteenDigits(double value) {
        return Fraction.FromDoubleRounded(value, 18);
    }
}
