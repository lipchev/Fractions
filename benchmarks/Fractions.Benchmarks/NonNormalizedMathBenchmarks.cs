﻿using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob(RuntimeMoniker.Net48)]
[ShortRunJob(RuntimeMoniker.Net90)]
public class NonNormalizedMathBenchmarks {
    public static IEnumerable<object[]> Operands() {
        // zero
        yield return [
            new Fraction(BigInteger.Zero, BigInteger.One, false),
            new Fraction(BigInteger.One, BigInteger.One, false)];
        // basic integers (powers of 10)
        yield return [
            new Fraction(1000, BigInteger.One, false),
            new Fraction(100, BigInteger.One, false)];
        // prime integers 
        yield return [
            new Fraction(97, BigInteger.One, false),
            new Fraction(89, BigInteger.One, false)];
        // something per hour (non-reducible)
        yield return [
            new Fraction(77, 3600, false),
            new Fraction(37, 3600, false)];
        // {-1024} and {-1/1024}
        yield return [
            new Fraction(-1024, 1, false),
            new Fraction(-1, 1024, false)];
        // {-45} and {1/6}
        yield return [
            new Fraction(-45, 1, false),
            new Fraction(1, 6, false)];
        // {-10^37} and {1/10^12}
        yield return [
            new Fraction(BigInteger.Pow(-10, 37), 1, false),
            new Fraction(1, BigInteger.Pow(10 , 12), false)];
        // 0.135 and 0.076 as non-normalized fractions
        yield return [
            new Fraction(135, 1000, false),
            new Fraction(76, 1000, false)];
        // 0.135 and 0.076 after reduction: {27/200} and {19/250}
        yield return [
            new Fraction(27, 200, false),
            new Fraction(19, 250, false)];
        // {42/66} and {36/96}
        yield return [
            new Fraction(42, 66, false),
            new Fraction(36, 96, false)];
        // {42/-96} and {36/-96}
        yield return [
            new Fraction(42, -96, false),
            new Fraction(36, -96, false)];
        yield return [
            Fraction.FromDouble(Math.PI, false),
            Fraction.FromDouble(Math.PI / 2, false)];
        // {245850922/78256779} and {0}
        yield return [
            Fraction.FromDoubleRounded(Math.PI, false),
            Fraction.Zero];
        // {245850922/78256779} and {NaN}
        yield return [
            Fraction.FromDoubleRounded(Math.PI, false),
            Fraction.NaN];
        // {245850922/78256779} and {Infinity}
        yield return [
            Fraction.FromDoubleRounded(Math.PI, false),
            Fraction.NegativeInfinity];
    }
    

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Add(Fraction a, Fraction b) {
        return a + b;
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Subtract(Fraction a, Fraction b) {
        return a - b;
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Multiply(Fraction a, Fraction b) {
        return a * b;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Divide(Fraction a, Fraction b) {
        return a / b;
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(Operands))]
    public Fraction Mod(Fraction a, Fraction b) {
        return a % b;
    }
}
