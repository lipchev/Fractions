﻿using System;
using NUnit.Framework;

namespace Fractions.Json.Tests;

public class Spec {
    [OneTimeSetUp]
    public void TestFixtureSetUp() {
        SetUp();
        Arrange();
        Act();
    }

    [OneTimeTearDown]
    public void TestFixtureTearDown() {
        TearDown();
    }

    public virtual void SetUp() { }

    public virtual void TearDown() { }

    public virtual void Arrange() { }

    public virtual void Act() { }
}
