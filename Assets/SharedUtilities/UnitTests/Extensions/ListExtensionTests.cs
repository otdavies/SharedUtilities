using System;
using System.Collections.Generic;
using NUnit.Framework;
using Psyfer.Utilities;

public class ListExtensionTests
{
    [Test]
    public void TestFilter()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> filtered = list.Filter(x => x % 2 == 0);
        Assert.AreEqual(filtered.Count, 5);
        Assert.AreEqual(filtered[0], 2);
        Assert.AreEqual(filtered[4], 10);
        Assert.AreEqual(filtered, list);
    }

    [Test]
    public void TestFilterCloned()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> filtered = list.FilterCloned(x => x % 2 == 0);
        Assert.AreEqual(filtered.Count, 5);
        Assert.AreEqual(filtered[0], 2);
        Assert.AreEqual(filtered[4], 10);
        Assert.AreNotSame(filtered, list);
    }

    [Test]
    public void TestReduce()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int sum = list.Reduce((x, y) => x + y);
        Assert.AreEqual(sum, 55);
    }

    [Test]
    public void TestMap()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> mapped = list.Map(x => x * 2);
        Assert.AreEqual(mapped.Count, 10);
        Assert.AreEqual(mapped[0], 2);
        Assert.AreEqual(mapped[9], 20);
    }

    [Test]
    public void TestMapTypeConversion
    ()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<string> mapped = list.Map(x => (x * 2).ToString());
        Assert.AreEqual(mapped.Count, 10);
        Assert.AreEqual(mapped[0], "2");
        Assert.AreEqual(mapped[9], "20");
    }

    [Test]
    public void TestFlatten()
    {
        List<List<int>> list = new() { new() { 1, 2, 3 }, new() { 4, 5, 6 }, new() { 7, 8, 9 } };
        List<int> flattened = list.Flatten();
        Assert.AreEqual(flattened.Count, 9);
        Assert.AreEqual(flattened[0], 1);
        Assert.AreEqual(flattened[8], 9);
    }

    [Test]
    public void TestShuffle()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        list.Shuffle();
        Assert.AreEqual(list.Count, 10);
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                return;
            }
        }
        Assert.Fail();
    }

    [Test]
    public void TestConcat()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> list2 = new() { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<int> concatenated = list.Concat(list2);
        Assert.AreEqual(concatenated.Count, 20);
        Assert.AreEqual(concatenated[0], 1);
        Assert.AreEqual(concatenated[19], 20);
        Assert.AreEqual(list, concatenated);
    }

    [Test]
    public void TestConcatCloned()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> list2 = new() { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        List<int> concatenated = list.ConcatCloned(list2);
        Assert.AreEqual(concatenated.Count, 20);
        Assert.AreEqual(concatenated[0], 1);
        Assert.AreEqual(concatenated[19], 20);
        Assert.AreNotSame(list, concatenated);
    }

    [Test]
    public void TestNthFromEnd()
    {
        List<int> list = new() { 1, 2, 3 };
        Assert.AreEqual(list.NthFromEnd(0), 3);
        Assert.AreEqual(list.NthFromEnd(1), 2);
        Assert.AreEqual(list.NthFromEnd(2), 1);
    }

    [Test]
    public void TestPushPopPeek()
    {
        List<int> list = new() { 1, 2, 3 };
        Assert.AreEqual(list.Peek(), 3);
        Assert.AreEqual(list.Pop(), 3);
        Assert.AreEqual(list.Peek(), 2);
        Assert.AreEqual(list.Pop(), 2);
        Assert.AreEqual(list.Peek(), 1);
        Assert.AreEqual(list.Pop(), 1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Peek());
        Assert.Throws<IndexOutOfRangeException>(() => list.Pop());
        list.Push(1);
        Assert.AreEqual(list.Peek(), 1);
        Assert.AreEqual(list.Pop(), 1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Peek());
        Assert.Throws<IndexOutOfRangeException>(() => list.Pop());
        Assert.True(list.IsEmpty());
    }

    [Test]
    public void TestCombined()
    {
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string combinedEvens = list.Filter(x => x % 2 == 0).Map(x => x.ToString()).Reduce((x, y) => x + y);
        Assert.AreEqual(combinedEvens, "246810");
    }
}
