using NUnit.Framework;
using Psyfer.Patterns;
using UnityEngine;

public class ObserverPatternTests
{
    internal class SomethingThatChanges : Observable<int>
    {
        public void Change(int value)
        {
            Notify(value);
        }
    }

    [Test]
    public void TestObserverPattern()
    {
        SomethingThatChanges subject = new();
        Observer<int> equalToOne = new Observer<int>(value => Assert.AreEqual(value, 1));
        Observer<int> greaterThanOne = new Observer<int>(value => Assert.Greater(value, 0));

        subject.Subscribe(equalToOne);
        subject.Subscribe(greaterThanOne);
        subject.Change(1);
        subject.Unsubscribe(equalToOne);
        subject.Change(2);
    }
}
