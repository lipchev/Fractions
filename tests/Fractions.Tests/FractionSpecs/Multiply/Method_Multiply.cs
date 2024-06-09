﻿using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Multiply;

[TestFixture]
// German: Wenn 0 mit 0 multipliziert wird
public class When_multiplying_0_by_0 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.Zero.Multiply(Fraction.Zero);
    }

    [Test]
    // German: Das Ergebnis sollte wieder 0 sein
    public void The_result_should_be_0_again() {
        _result.Should().Be(Fraction.Zero);
    }
}

[TestFixture]
// German: Wenn 1 mit 0 multipliziert wird
public class When_multiplying_1_by_0 : Spec {
    private Fraction _result1;
    private Fraction _result2;

    public override void Act() {
        _result1 = Fraction.One.Multiply(Fraction.Zero);
        _result2 = Fraction.Zero.Multiply(Fraction.One);
    }

    [Test]
    // German: Das Ergebnis sollte wieder 0 sein
    public void The_result_should_be_0_again() {
        _result1.Should().Be(Fraction.Zero);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        _result1.Should().Be(_result2);
    }
}

[TestFixture]
// German: Wenn ein Fünftel mit ein Fünftel multipliziert wird
public class When_multiplying_one_fifth_by_one_fifth : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result;

    public override void SetUp() {
        _a = new Fraction(1, 5);
        _b = new Fraction(1, 5);
    }

    public override void Act() {
        _result = _a.Multiply(_b);
    }

    [Test]
    // German: Das Ergebnis sollte ein Fünfundzwanzigstel sein
    public void The_result_should_be_one_twenty_fifth() {
        _result.Should().Be(new Fraction(1, 25));
    }
}

[TestFixture]
// German: Wenn 2 mit 2 Viertel multipliziert wird
public class When_multiplying_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result1;
    private Fraction _result2;

    public override void SetUp() {
        _a = new Fraction(2, 1);
        _b = new Fraction(2, 4);
    }

    public override void Act() {
        _result1 = _a.Multiply(_b);
        _result2 = _b.Multiply(_a);
    }

    [Test]
    // German: Das Ergebnis sollte 1 sein
    public void The_result_should_be_1() {
        _result1.Should().Be(Fraction.One);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        _result1.Should().Be(_result2);
    }
}

[TestFixture]
public class When_multiplying_2_by_2_quarters_without_normalization : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result1;
    private Fraction _result2;
    private Fraction _normalizedResult;

    public override void SetUp() {
        _a = new Fraction(2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result1 = _a.Multiply(_b);
        _result2 = _b.Multiply(_a);
        _normalizedResult = _result1.Reduce();
    }

    [Test]
    // German: Das Ergebnis sollte 2/2 sein
    public void The_result_should_be_2_over_2() {
        Assert.That(_result1, Is.EqualTo(new Fraction(2, 2, false)).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_normalized_result_should_be_1() {
        _normalizedResult.Should().Be(Fraction.One);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        Assert.That(_result1, Is.EqualTo(_result2).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
// German: Wenn minus 2 mit 2 Viertel multipliziert wird
public class When_multiplying_minus_2_by_2_quarters : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result1;
    private Fraction _result2;

    public override void SetUp() {
        _a = new Fraction(-2, 1);
        _b = new Fraction(2, 4);
    }

    public override void Act() {
        _result1 = _a.Multiply(_b);
        _result2 = _b.Multiply(_a);
    }

    [Test]
    // German: Das Ergebnis sollte minus 1 sein
    public void The_result_should_be_minus_1() {
        _result1.Should().Be(Fraction.MinusOne);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        _result1.Should().Be(_result2);
    }
}

[TestFixture]
public class When_multiplying_minus_2_by_2_quarters_without_normalization : Spec {
    private Fraction _a;
    private Fraction _b;
    private Fraction _result1;
    private Fraction _result2;
    private Fraction _normalizedResult;

    public override void SetUp() {
        _a = new Fraction(-2, 1, false);
        _b = new Fraction(2, 4, false);
    }

    public override void Act() {
        _result1 = _a.Multiply(_b);
        _result2 = _b.Multiply(_a);
        _normalizedResult = _result1.Reduce();
    }

    [Test]
    public void The_result_should_be_minus_2_over_2() {
        Assert.That(_result1, Is.EqualTo(new Fraction(-2, 2, false)).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_normalized_result_should_be_minus_1() {
        _normalizedResult.Should().Be(Fraction.MinusOne);
    }

    [Test]
    // German: Die Operation sollte kommutativ sein
    public void The_operation_should_be_commutative() {
        Assert.That(_result1, Is.EqualTo(_result2).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
public class When_multiplying_with_NaN {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // NaN with NaN
            yield return new TestCaseData(Fraction.NaN, Fraction.NaN, Fraction.NaN);
            // NaN with any number
            yield return new TestCaseData(Fraction.NaN, Fraction.PositiveInfinity, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, 4), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, -5, false), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.One, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(4, 5), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.Zero, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.MinusOne, Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-5, 4), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(-4, 5), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, new Fraction(5, -5, false), Fraction.NaN);
            yield return new TestCaseData(Fraction.NaN, Fraction.NegativeInfinity, Fraction.NaN);
            // Any number with NaN
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(5, 4), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.One, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(4, 5), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.Zero, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.MinusOne, Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-5, 4), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(new Fraction(-4, 5), Fraction.NaN, Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NaN, Fraction.NaN);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_always_NaN(Fraction a, Fraction b, Fraction expected) {
        var result = a.Multiply(b);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
public class When_multiplying_with_infinity {
    private static IEnumerable<TestCaseData> TestCases {
        get {
            // positive infinity with positive infinity
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.PositiveInfinity,
                Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 0, false),
                Fraction.PositiveInfinity);

            // positive infinity with any other number
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(5, 4), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.One, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(4, 5), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.Zero, Fraction.NaN);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.MinusOne, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 4), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-4, 5), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, Fraction.NegativeInfinity,
                Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.PositiveInfinity, new Fraction(-5, 0, false),
                Fraction.NegativeInfinity);

            // negative infinity with negative infinity
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.NegativeInfinity,
                Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 0, false),
                Fraction.PositiveInfinity);

            // negative infinity with any other number
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 4), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.One, Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(4, 5), Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.Zero, Fraction.NaN);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.MinusOne, Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-5, 4), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(-4, 5), Fraction.PositiveInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, Fraction.PositiveInfinity,
                Fraction.NegativeInfinity);
            yield return new TestCaseData(Fraction.NegativeInfinity, new Fraction(5, 0, false),
                Fraction.NegativeInfinity);
        }
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_always_NaN_or_Infinity(Fraction a, Fraction b, Fraction expected) {
        var result = a.Multiply(b);
        Assert.That(result, Is.EqualTo(expected).Using(StrictTestComparer.Instance));
    }
}

[TestFixture]
public class When_multiplying_with_zero {
    private static IEnumerable<TestCaseData> TestCases {
        get {

            // {0/1} * {1/10} = Zero
            yield return new TestCaseData(
                Fraction.Zero,
                new Fraction(1, 10, false));

            // {0/-1} * {1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -1, false),
                new Fraction(1, 10, false));

            // {0/10} * {1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, 10, false),
                new Fraction(1, 10, false));

            // {0/-10} * {1/10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -10, false),
                new Fraction(1, 10, false));
            
            // {0/10} * {-1/-10} = Zero
            yield return new TestCaseData(
                new Fraction(0, 10, false),
                new Fraction(-1, -10, false));
            
            // {0/-10} * {-1/-10} = Zero
            yield return new TestCaseData(
                new Fraction(0, -10, false),
                new Fraction(-1, -10, false));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void The_result_is_Zero(Fraction a, Fraction b) {
        Assert.That(a.Multiply(b), Is.EqualTo(Fraction.Zero).Using(StrictTestComparer.Instance));  // a * b = c
        Assert.That(b.Multiply(a), Is.EqualTo(Fraction.Zero).Using(StrictTestComparer.Instance));  // b * a = c
    }
    
}

[TestFixture]
public class When_multiplying_without_normalization {
    private static IEnumerable<TestCaseData> PositiveResultCases {
        get {
            #region 0.1m * 0.1XX
            
            // {1/10} * {1/10} == {1/100} 
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(1, 10, false),
                    new Fraction(1, 100, false));
            
            // {1/10} * {10/100} == {1/100}     // the denominator should be reduced (0.01m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(10, 100, false),
                    new Fraction(1, 100, false));
            
            // {1/10} * {100/1000} == {10/1000}     // the denominator should be reduced, but not completely (0.1m * 0.100m = 0.010m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(100, 1000, false),
                    new Fraction(10, 1000, false));
            
            #endregion
            
            #region 0.1m * 0.5XX
            
            // {1/10} * {5/10} == {1/20}        // the denominator should be reduced incrementally (x * 0.5 * 0.2 should be the same as x * 0.1)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(5, 10, false),
                    new Fraction(1, 20, false));
            
            // {1/10} * {50/100} == {5/100}     // the denominator should be reduced, but not completely (0.1m * 0.50m = 0.05m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(50, 100, false),
                    new Fraction(5, 100, false));
            
            // {1/10} * {500/1000} == {50/1000}     // the denominator should be reduced, but not completely (0.1m * 0.500m = 0.050m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(500, 1000, false),
                    new Fraction(50, 1000, false));
            
            #endregion
            
            #region 0.1m * 1.XX
            
            // {1/10} * {1/1} == {1/10}
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(1, 1, false),
            new Fraction(1, 10, false));
            
            // {1/10} * {10/10} == {1/10}       // the denominator should be reduced (0.1m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(10, 10, false),
                    new Fraction(1, 10, false));
            
            // {1/10} * {100/100} == {10/100}   // the denominator should be reduced, but not completely (0.1m * 1.0m = 0.10m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(100, 100, false),
                    new Fraction(10, 100, false));
            
            #endregion
            
            #region 0.1m * 5.XX
            
            // {1/10} * {5/1} == {1/2}         // the denominator should be reduced incrementally (x * 5 * 2 should be the same as x * 10)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(5, 1, false),
                    new Fraction(1, 2, false));
            
            // {1/10} * {50/10} == {5/10}       // the denominator should be reduced (0.5m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(50, 10, false),
                    new Fraction(5, 10, false));
            
            // {1/10} * {500/100} == {50/100}   // the denominator should be reduced, but not completely (0.1m * 5.0m = 0.50m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(500, 100, false),
                    new Fraction(50, 100, false));
            
            #endregion
            
            #region 0.1m * 10.XX
            
            // {1/10} * {10/1} == {1/1}         // the denominator should be reduced (1m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(10, 1, false),
                    new Fraction(1, 1, false));
            
            // {1/10} * {100/10} == {10/10}     // the denominator should be reduced, but not completely (0.1m * 10.0m = 1.0m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(100, 10, false),
                    new Fraction(10, 10, false));
            
            // {1/10} * {1000/100} == {100/100}     // the denominator should be reduced, but not completely (0.1m * 10.00m = 1.00m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(1000, 100, false),
                    new Fraction(100, 100, false));
            
            #endregion
            
            #region 0.1m * 50.XX
            
            // {1/10} * {50/1} == {5/1}         // the denominator should be reduced (5m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(50, 1, false),
                    new Fraction(5, 1, false));
            
            // {1/10} * {500/10} == {50/10}     // the denominator should be reduced, but not completely (0.1m * 50.0m = 5.0m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(500, 10, false),
                    new Fraction(50, 10, false));
            
            // {1/10} * {5000/100} == {500/100}     // the denominator should be reduced, but not completely (0.1m * 50.00m = 5.00m)
            yield return new TestCaseData(
                    new Fraction(1, 10, false),
                    new Fraction(5000, 100, false),
                    new Fraction(500, 100, false));
            
            #endregion
            
            #region 0.10m * 0.1XX
            
            // {10/100} * {1/10} == {1/100} 
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1, 10, false),
                    new Fraction(1, 100, false));
            
            // {10/100} * {10/100} == {1/100}     // the denominator should be reduced, but not completely (0.10m * 0.10m = 0.01m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10, 100, false),
                    new Fraction(1, 100, false));
            
            // {10/100} * {100/1000} == {1/100}   // the denominator should be reduced, but not completely (0.10m * 0.100m = 0.01m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(100, 1000, false),
                    new Fraction(1, 100, false));
            
            // {10/100} * {1000/10000} == {10/1000} // the denominator should be reduced, but not completely (0.10m * 0.1000m = 0.0010m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1000, 10000, false),
                    new Fraction(10, 1000, false));
            
            #endregion
            
            #region 0.10m * 0.5XX
            
            // {10/100} * {5/10} == {1/20}       // the denominator should be reduced incrementally (x * 0.5 * 0.2 should be the same as x * 0.1)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5, 10, false),
                    new Fraction(1, 20, false));
            
            // {10/100} * {50/100} == {1/20}     // the denominator should be reduced incrementally (x * 0.50 * 0.20 should be the same as x * 0.10)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50, 100, false),
                    new Fraction(1, 20, false));
            
            // {10/100} * {500/1000} == {5/100}   // the denominator should be reduced, but not completely (0.10m * 5.00m = 0.5m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(500, 1000, false),
                    new Fraction(5, 100, false));
            
            // {10/100} * {5000/10000} == {50/1000} // the denominator should be reduced, but not completely (0.10m * 5.000m = 0.50m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5000, 10000, false),
                    new Fraction(50, 1000, false));
            
            #endregion
            
            #region 0.10m * 1.XX
            
            // {10/100} * {1/1} == {10/100}
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1, 1, false),
                    new Fraction(10, 100, false));
            
            // {10/100} * {10/10} == {1/10}       // the denominator should be reduced completely (0.10m * 1.0m = 0.1m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10, 10, false),
                    new Fraction(1, 10, false));
            
            // {10/100} * {100/100} == {1/10}     // the denominator should be reduced, but not completely (0.10m * 1.00m = 0.1m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(100, 100, false),
                    new Fraction(1, 10, false));
            
            // {10/100} * {1000/1000} == {10/100}   // the denominator should be reduced, but not completely (0.10m * 1.000m = 0.10m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1000, 1000, false),
                    new Fraction(10, 100, false));
            
            #endregion
            
            #region 0.10m * 5.XX
            
            // {10/100} * {5/1} == {10/20}          // the denominator should be reduced incrementally (x * 5 * 2 should be the same as x * 10)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5, 1, false),
                    new Fraction(10, 20, false));
            
            // {10/100} * {50/10} == {1/2}       // the denominator should be reduced incrementally (x * 5.0 * 2.0 should be the same as x * 10.0)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50, 10, false),
                    new Fraction(1, 2, false));
            
            // {10/100} * {500/100} == {5/10}     // the denominator should be reduced, but not completely (0.10m * 5.00m = 0.5m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(500, 100, false),
                    new Fraction(5, 10, false));
            
            // {10/100} * {5000/1000} == {50/100}   // the denominator should be reduced, but not completely (0.10m * 5.000m = 0.50m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5000, 1000, false),
                    new Fraction(50, 100, false));
            
            #endregion
            
            #region 0.10m * 10.XX
            
            // {10/100} * {10/1} == {10/10}     // the denominator should be reduced, but not completely (0.10m * 10m = 1.0m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10, 1, false),
                    new Fraction(10, 10, false));
            
            // {10/100} * {100/10} == {1/1}     // the denominator should be reduced completely (0.10m * 10.0m = 1m) 
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(100, 10, false),
                    new Fraction(1, 1, false));
            
            // {10/100} * {1000/100} == {10/10} // the denominator should be reduced, but not completely (0.10m * 10.00m = 1.0m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(1000, 100, false),
                    new Fraction(10, 10, false));
            
            // {10/100} * {10000/1000} == {100/100} // the denominator should be reduced, but not completely (0.10m * 10.000m = 1.00m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(10000, 1000, false),
                    new Fraction(100, 100, false));
            
            #endregion
            
            #region 0.10m * 50.XX
            
            // {10/100} * {50/1} == {10/2}         // the denominator is preserved
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50, 1, false),
                    new Fraction(10, 2, false));
            
            // {10/100} * {500/10} == {5/1}     // the denominator should be increased
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(500, 10, false),
                    new Fraction(5, 1, false));
            
            // {10/100} * {5000/100} == {50/10} // the denominator should be increased
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(5000, 100, false),
                    new Fraction(50, 10, false));
            
            // {10/100} * {50000/1000} == {500/100} // the denominator should be reduced, but not completely (0.10m * 50.000m = 5.00m)
            yield return new TestCaseData(
                    new Fraction(10, 100, false),
                    new Fraction(50000, 1000, false),
                    new Fraction(500, 100, false));
            
            #endregion

            #region other values

            // {1/10} * {3/10} == {3/100} 
            yield return new TestCaseData(
                new Fraction(1, 10, false),
                new Fraction(3, 10, false),
                new Fraction(3, 100, false));
            
            // 1/3 * 10/1 == {10/3}
            yield return new TestCaseData(
                new Fraction(1, 3, false),
                new Fraction(10, 1, false),
                new Fraction(10, 3, false));
            
            // {20/10} * {10/25} = {20/10} / {25/10} = {(0 + 20/25) / (1 + 0/10)} = {(20/25)/(1)} = {20/25}
            yield return new TestCaseData(
                new Fraction(20, 10, false),
                new Fraction(10, 25, false),
                new Fraction(20, 25, false));
            
            // {9/7} * {3/4} = {9/7} / {4/3} = {(2 + 1/4) / (2 + 1/3)} = {(9/4)/(7/3)} = {27/28}
            yield return new TestCaseData(
                new Fraction(9, 7, false),
                new Fraction(3, 4, false),
                new Fraction(27, 28, false));

            #endregion
        }
    }


    [Test]
    [TestCaseSource(nameof(PositiveResultCases))]
    public void The_terms_expansion_is_constrained(Fraction a, Fraction b, Fraction expectedValue) {
        // Assert.That(result, Is.EqualTo(expectedValue));
        // positive results
        Assert.That(a.Multiply(b), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // a * b = c
        Assert.That(b.Multiply(a), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // b * a = c
        Assert.That(a.Reciprocal().Multiply(b.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/a * 1/b = 1/c
        Assert.That(b.Reciprocal().Multiply(a.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/b * 1/a = 1/c
        
        Assert.That(a.Negate().Multiply(b.Negate()), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // -a * -b = c
        Assert.That(b.Negate().Multiply(a.Negate()), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // -b * -a = c
        Assert.That(a.Reciprocal().Negate().Multiply(b.Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // -1/a * -1/b = 1/c
        Assert.That(b.Reciprocal().Negate().Multiply(a.Reciprocal().Negate()), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // -1/b * -1/a = 1/c
        Assert.That(a.Negate().Reciprocal().Multiply(b.Negate().Reciprocal()), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/-a * 1/-b = 1/c
        Assert.That(b.Negate().Reciprocal().Multiply(a.Negate().Reciprocal()), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/-b * 1/-a = 1/c

        // negative results
        Assert.That(a.Negate().Multiply(b), Is.EqualTo(expectedValue.Negate()).Using(StrictTestComparer.Instance));  // -a * b = -c
        Assert.That(b.Negate().Multiply(a), Is.EqualTo(expectedValue.Negate()).Using(StrictTestComparer.Instance));  // -b * a = -c
        Assert.That(a.Reciprocal().Negate().Multiply(b.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate()).Using(StrictTestComparer.Instance)); // -1/a * 1/b = -1/c
        Assert.That(b.Reciprocal().Negate().Multiply(a.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate()).Using(StrictTestComparer.Instance)); // -1/b * 1/a = -1/c
        Assert.That(a.Negate().Reciprocal().Multiply(b.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate()).Using(StrictTestComparer.Instance)); // 1/-a * 1/b = -1/c
        Assert.That(b.Negate().Reciprocal().Multiply(a.Reciprocal()), Is.EqualTo(expectedValue.Reciprocal().Negate()).Using(StrictTestComparer.Instance)); // 1/-b * 1/a = -1/c

    //     Assert.That(a.Negate().Multiply(b.Negate()).Abs(), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // -a * -b = c
    //     a.Negate().Multiply(b.Negate()).IsPositive.Should().BeTrue();
    //     
    //     Assert.That(b.Negate().Multiply(a.Negate()).Abs(), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // -b * -a = c
    //     b.Negate().Multiply(a.Negate()).IsPositive.Should().BeTrue();
    //     
    //     Assert.That(a.Reciprocal().Negate().Multiply(b.Reciprocal().Negate()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // -1/a * -1/b = 1/c
    //     a.Reciprocal().Negate().Multiply(b.Reciprocal().Negate()).IsPositive.Should().BeTrue();
    //     
    //     Assert.That(b.Reciprocal().Negate().Multiply(a.Reciprocal().Negate()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // -1/b * -1/a = 1/c
    //     b.Reciprocal().Negate().Multiply(a.Reciprocal().Negate()).IsPositive.Should().BeTrue();
    //
    //     Assert.That(a.Negate().Reciprocal().Multiply(b.Negate().Reciprocal()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/-a * 1/-b = 1/c
    //     a.Negate().Reciprocal().Multiply(b.Negate().Reciprocal()).IsPositive.Should().BeTrue();
    //     
    //     Assert.That(b.Negate().Reciprocal().Multiply(a.Negate().Reciprocal()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/-b * 1/-a = 1/c
    //     b.Negate().Reciprocal().Multiply(a.Negate().Reciprocal()).IsPositive.Should().BeTrue();
    //
    //     
    //     Assert.That(a.Negate().Multiply(b).Abs(), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // -a * b = -c
    //     a.Negate().Multiply(b).IsNegative.Should().BeTrue();
    //     
    //     Assert.That(b.Negate().Multiply(a).Abs(), Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));  // -b * a = -c
    //     b.Negate().Multiply(a).IsNegative.Should().BeTrue();
    //     
    //     Assert.That(a.Reciprocal().Negate().Multiply(b.Reciprocal()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // -1/a * 1/b = -1/c
    //     a.Reciprocal().Negate().Multiply(b.Reciprocal()).IsNegative.Should().BeTrue();
    //     
    //     Assert.That(b.Reciprocal().Negate().Multiply(a.Reciprocal()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // -1/b * 1/a = -1/c
    //     b.Reciprocal().Negate().Multiply(a.Reciprocal()).IsNegative.Should().BeTrue();
    //
    //     Assert.That(a.Negate().Reciprocal().Multiply(b.Reciprocal()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/-a * 1/b = -1/c
    //     a.Negate().Reciprocal().Multiply(b.Reciprocal()).IsNegative.Should().BeTrue();
    //     
    //     Assert.That(b.Negate().Reciprocal().Multiply(a.Reciprocal()).Abs(), Is.EqualTo(expectedValue.Reciprocal()).Using(StrictTestComparer.Instance)); // 1/-b * 1/a = -1/c
    //     b.Negate().Reciprocal().Multiply(a.Reciprocal()).IsNegative.Should().BeTrue();
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_multiplied_by_small_integers() {
        // Arrange: {10/100} * 10 = {10 /10}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(10, 10, false);
        // Act
        var multipliedByTen = initialValue * 10;
        var multipliedByTwoAndFive = initialValue * 2 * 5;
        var multipliedByFiveAndTwo = initialValue * 5 * 2;
        // Assert
        Assert.That(multipliedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_multiplied_by_integers_large_and_small() {
        // Arrange: {10/100} * 10_000 = 1_000 
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(1_000, 1, false);
        // Act
        var multipliedByTen = initialValue * 10_000;
        var multipliedByTwoAndFive = initialValue * 2_000 * 5;
        var multipliedByFiveAndTwo = initialValue * 5_000 * 2;
        // Assert
        Assert.That(multipliedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_multiplied_by_integers_small_and_large() {
        // Arrange: {10/100} * 10_000 = 1_000
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(1_000, 1, false);
        // Act
        var multipliedByTen = initialValue * 10_000;
        var multipliedByTwoAndFive = initialValue * 5 * 2_000;
        var multipliedByFiveAndTwo = initialValue * 2 * 5_000;
        // Assert
        Assert.That(multipliedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_numerator_is_increased_incrementally_when_multiplied_by_integers_large_and_large() {
        // Arrange: {10/100} * 10_000_000 = 1_000_000
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(1_000_000, 1, false);
        // Act
        var multipliedByTen = initialValue * 10_000_000;
        var multipliedByTwoAndFive = initialValue * 5_000 * 2_000;
        var multipliedByFiveAndTwo = initialValue * 2_000 * 5_000;
        // Assert
        Assert.That(multipliedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_multiplied_by_one_over_small_integer() {
        // Arrange: {10/100} * {1/10} = {1/100}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(1, 100, false);
        // Act
        var multipliedByTen = initialValue * 0.1m;
        var multipliedByTwoAndFive = initialValue * 0.2m * 0.5m;
        var multipliedByFiveAndTwo = initialValue * 0.5m * 0.2m;
        // Assert
        Assert.That(multipliedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }

    [Test]
    public void The_resulting_denominator_is_increased_incrementally_when_multiplied_by_one_over_large_integer() {
        // Arrange: {10/100} * {1/10_000} = {1/100_000}
        var initialValue = new Fraction(10, 100, false);
        var expectedValue = new Fraction(1, 100_000, false);
        // Act
        var multipliedByTen = initialValue * 0.0001m;
        var multipliedByTwoAndFive = initialValue * 0.0002m * 0.5m;
        var multipliedByFiveAndTwo = initialValue * 0.0005m * 0.2m;
        // Assert
        Assert.That(multipliedByTen, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByTwoAndFive, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
        Assert.That(multipliedByFiveAndTwo, Is.EqualTo(expectedValue).Using(StrictTestComparer.Instance));
    }
}
