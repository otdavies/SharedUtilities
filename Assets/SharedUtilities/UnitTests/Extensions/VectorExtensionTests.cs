using NUnit.Framework;
using Psyfer.Utilities;
using UnityEngine;

public class VectorExtensionTests
{
    [Test]
    public void Multiply()
    {
        Vector3 vector = new(1, 2, 3);
        Vector3 result = vector.Multiply(Vector3.one * 2);
        Assert.AreEqual(2, result.x);
        Assert.AreEqual(4, result.y);
        Assert.AreEqual(6, result.z);
    }

    [Test]
    public void Abs()
    {
        Vector3 vector = new(-1, -2, -3);
        Vector3 result = vector.Abs();
        Assert.AreEqual(1, result.x);
        Assert.AreEqual(2, result.y);
        Assert.AreEqual(3, result.z);
    }
}
