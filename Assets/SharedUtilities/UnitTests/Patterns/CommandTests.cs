using NUnit.Framework;
using Psyfer.Patterns;
using UnityEngine;

public class CommandPatternTests
{
    internal class Layer
    {
        public int Order { get; private set; }

        public void MoveUp()
        {
            this.Order--;
        }

        public void MoveDown()
        {
            this.Order++;
        }

        public bool OnTop() => Order <= 0;
    }


    [Test]
    public void TestCommandPattern()
    {
        // For non-reference types (structs) we need to use CommandByValue
        // The situations where we would use this are pretty limited, so it is here for completeness
        float value = 0;
        CommandByValue<float> add = new CommandByValue<float>(value, (float value) => value + 1f, (float value) => value - 1f);
        add.Execute();
        value = add.Value();
        Assert.AreEqual(value, 1f);

        Vector3 vector = new(1, 2, 3);
        CommandByValue<Vector3> command = new CommandByValue<Vector3>(vector, (Vector3 v) => v * 3, (Vector3 v) => v * (1.0f / 3.0f));
        command.Execute();
        Assert.AreEqual(command.Value(), new Vector3(3, 6, 9));
        command.Undo();
        Assert.AreEqual(command.Value(), new Vector3(1, 2, 3));

        // For reference types we use Command
        Layer someLayer = new();

        // We want some commands that mutate the state of the layer
        ICommand layerMoveDown = new Command<Layer>(someLayer, (Layer l) => l.MoveDown(), (Layer l) => l.MoveUp());
        ICommand layerMoveUp = new Command<Layer>(someLayer, (Layer l) => l.MoveUp(), (Layer l) => l.MoveDown());

        layerMoveDown.Execute();
        Assert.IsFalse(someLayer.OnTop());
        layerMoveUp.Execute();
        Assert.IsTrue(someLayer.OnTop());
        layerMoveUp.Undo();
        Assert.IsFalse(someLayer.OnTop());
    }
}
