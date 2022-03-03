using NUnit.Framework;
using Psyfer.Utilities;
using UnityEngine;

public class NumericalExtensionTests
{
    [Test]
    public void TestLinearRemap()
    {
        float val = 1;
        float remapped = val.Remap(0, 2, 0, 1);
        Assert.AreEqual(remapped, 0.5f);
        Assert.AreEqual(val, 1);

        remapped = val.Remap(0, 1, 0, 2);
        Assert.AreEqual(remapped, 2);

        val = -100;
        remapped = val.Remap(-100, 0, 1, 2);
        Assert.AreEqual(remapped, 1);
    }

    [Test]
    public void TestClamp()
    {
        float val = 1;
        float clamped = val.Clamp(0, 2);
        Assert.AreEqual(clamped, 1);
        Assert.AreEqual(val, 1);

        clamped = val.Clamp(-100, 0);
        Assert.AreEqual(clamped, 0);

        val = 100;
        clamped = val.Clamp(-100, 99);
        Assert.AreEqual(clamped, 99);

        val = -100;
        clamped = val.Clamp(-100, 0);
        Assert.AreEqual(clamped, -100);
    }

    [Test]
    public void TestSinLerp()
    {
        float val = 1;
        float sin = val.SinLerp(0, 2, 0.5f);
        Assert.Greater(sin, 0);
        Assert.Less(sin, 2);

        sin = sin.SinLerp(0, 1, -10);
        Assert.AreEqual(sin, 0);

        sin = sin.SinLerp(0, 1, 2);
        Assert.AreEqual(sin, 1);

        sin = sin.SinLerp(-10, 1, 0);
        Assert.AreEqual(sin, -10);
    }

    [Test]
    public void TestCosLerp()
    {
        float val = 1;
        float cos = val.CosLerp(0, 2, 0.5f);
        Assert.Greater(cos, 0);
        Assert.Less(cos, 2);

        cos = cos.CosLerp(0, 1, -10);
        Assert.AreEqual(cos, 0);

        cos = cos.CosLerp(0, 1, 2);
        Assert.AreEqual(cos, 1);

        cos = cos.CosLerp(-10, 1, 0);
        Assert.AreEqual(cos, -10);
    }

    [Test]
    public void TestSmoothStepLerp()
    {
        float val = 1;
        float smooth = val.SmoothStepLerp(0, 2, 0.5f);
        Assert.Greater(smooth, 0);
        Assert.Less(smooth, 2);

        smooth = smooth.SmoothStepLerp(0, 1, -10);
        Assert.AreEqual(smooth, 0);

        smooth = smooth.SmoothStepLerp(0, 1, 2);
        Assert.AreEqual(smooth, 1);

        smooth = smooth.SmoothStepLerp(-10, 1, 0);
        Assert.AreEqual(smooth, -10);
    }
}
