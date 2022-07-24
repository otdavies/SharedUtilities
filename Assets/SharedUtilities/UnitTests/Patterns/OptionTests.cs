using NUnit.Framework;
using Psyfer.Patterns;
using UnityEngine;

public class OptionPatternTests
{
    [Test]
    public void TestOptionPattern()
    {
        Option<int> option = new(1);
        Assert.IsTrue(option.Some);
        Assert.AreEqual(1, option.Unwrap());

        Option<int> unitializedOption = new();
        Assert.IsFalse(unitializedOption.Some);
        Assert.Throws<System.Exception>(() => unitializedOption.Unwrap());

        Option<string> stringOption = "Hello";
        Assert.IsTrue(stringOption.Some);
        Assert.AreEqual("Hello", stringOption.Unwrap());
    }
}