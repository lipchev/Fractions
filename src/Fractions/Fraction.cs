﻿using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;
using Fractions.TypeConverters;

namespace Fractions;

/// <summary>
/// A mathematical fraction. A rational number written as a/b (a is the numerator and b the denominator). 
/// The data type is not capable to store NaN (not a number) or infinite.
/// </summary>
[TypeConverter(typeof(FractionTypeConverter))]
[StructLayout(LayoutKind.Sequential)]
public readonly partial struct Fraction : IEquatable<Fraction>, IComparable, IComparable<Fraction>, IFormattable {
    private static readonly BigInteger TEN = new(10);

    private readonly BigInteger? _denominator;

    /// <summary>
    /// A fraction representing the positive infinity.
    /// </summary>
    public static Fraction PositiveInfinity { get; } = new(BigInteger.One, BigInteger.Zero, FractionState.IsNormalized);

    /// <summary>
    /// A fraction representing the negative infinity.
    /// </summary>
    public static Fraction NegativeInfinity { get; } = new(BigInteger.MinusOne, BigInteger.Zero, FractionState.IsNormalized);

    /// <summary>
    /// A fraction representing the result of dividing zero by zero.
    /// </summary>
    public static Fraction NaN { get; } = new(BigInteger.Zero, BigInteger.Zero, FractionState.IsNormalized);

    /// <summary>
    /// A fraction with the reduced/simplified value of 0.
    /// </summary>
    public static Fraction Zero { get; } = new(BigInteger.Zero, BigInteger.One, FractionState.IsNormalized);

    /// <summary>
    /// A fraction with the reduced/simplified value of 1.
    /// </summary>
    public static Fraction One { get; } = new(BigInteger.One, BigInteger.One, FractionState.IsNormalized);

    /// <summary>
    /// A fraction with the reduced/simplified value of 2.
    /// </summary>
    public static Fraction Two { get; } = new(new BigInteger(2), BigInteger.One, FractionState.IsNormalized);

    /// <summary>
    /// A fraction with the reduced/simplified value of -1.
    /// </summary>
    public static Fraction MinusOne { get; } = new(BigInteger.MinusOne, BigInteger.One, FractionState.IsNormalized);

    /// <summary>
    /// The numerator.
    /// </summary>
    public BigInteger Numerator { get; }

    /// <summary>
    /// The denominator
    /// </summary>
    public BigInteger Denominator => _denominator.GetValueOrDefault(BigInteger.One);

    /// <summary>
    /// <c>true</c> if the fraction represents a valid number or <c>false</c> otherwise.
    /// </summary>
    public bool IsNaN => Denominator.IsZero && Numerator.IsZero;

    /// <summary>
    /// <c>true</c> if the fraction evaluates to positive or negative infinity or <c>false</c> otherwise.
    /// </summary>
    public bool IsInfinity => Denominator.IsZero && !Numerator.IsZero;

    /// <summary>
    /// <c>true</c> if the fraction evaluates to positive infinity or <c>false</c> otherwise.
    /// </summary>
    public bool IsPositiveInfinity => Denominator.IsZero && Numerator.Sign == 1;

    /// <summary>
    /// <c>true</c> if the fraction evaluates to negative infinity or <c>false</c> otherwise.
    /// </summary>
    public bool IsNegativeInfinity => Denominator.IsZero && Numerator.Sign == -1;

    /// <summary>
    ///     <c>true</c> if the value is greater than zero or <c>false</c> otherwise.
    /// </summary>
    public bool IsPositive => Numerator.Sign switch {
        0 => false,
        1 => Denominator.Sign >= 0,
        _ => Denominator.Sign < 0
    };

    /// <summary>
    /// <c>true</c> if the value is lesser than zero or <c>false</c> otherwise.
    /// </summary>
    public bool IsNegative => Numerator.Sign switch {
        0 => false,
        -1 => Denominator.Sign >= 0,
        _ => Denominator.Sign < 0
    };

    /// <summary>
    /// <c>true</c> if the fraction represents the value 0 or <c>false</c> otherwise.
    /// </summary>
    public bool IsZero => Numerator.IsZero && !Denominator.IsZero;

    /// <summary>
    /// The fraction's state.
    /// </summary>
    public FractionState State { get; }
}
