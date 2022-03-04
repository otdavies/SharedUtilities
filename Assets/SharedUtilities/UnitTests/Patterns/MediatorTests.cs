using NUnit.Framework;
using Psyfer.Patterns;
using UnityEngine;

public class MediatorPatternTests
{
    internal class Participant : IMediatable<Message>
    {
        public string Name { get; private set; }
        public Message LastMessage { get; private set; }

        public Participant(string name)
        {
            Name = name;
        }

        public void Receive(IMediatable<Message> from, Message message)
        {
            // Debug.Log($"{Name} received {message.Text} from {(from as Participant).Name}");
            LastMessage = message;
        }
    }

    internal class Message
    {
        public string Text { get; private set; }

        public Message(string text)
        {
            Text = text;
        }
    }

    [Test]
    public void TestMediatorPattern()
    {
        // Our mediator uses a string as a key and passes Messages
        Mediator<string, Message> mediator = new();

        // We'll put this in a block to show that it doesn't matter if participants go out of scope
        {
            // Create and name our participents
            Participant fred = new("Fred");
            Participant wilma = new("Wilma");

            // We will use participants names as keys
            mediator.Register(fred.Name, fred);
            mediator.Register(wilma.Name, wilma);

            // Send a message
            mediator.Send(wilma.Name, fred, new Message("Hello wilma"));
            Assert.AreEqual(wilma.LastMessage.Text, "Hello wilma");

            // Respond
            mediator.Send(fred.Name, wilma, new Message("Hello fred"));
            Assert.AreEqual(fred.LastMessage.Text, "Hello fred");
        }

        // Missed the party, but can still try to send a message
        Participant barney = new("Barney");
        mediator.Register(barney.Name, barney);
        mediator.Send("wilma", barney, new Message("Me third!"));
    }
}
