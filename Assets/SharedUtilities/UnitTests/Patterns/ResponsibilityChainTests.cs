using NUnit.Framework;
using Psyfer.Patterns;
using UnityEngine;

public class ResponsibilityChainPatternTests
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

        public bool OnTop() => Order == 0;
    }

    internal class TopLayers : IResponsible<Layer>
    {
        public bool IsResponsible(Layer layer) => layer.OnTop();

        public Layer Handle(Layer layer)
        {
            layer.MoveDown();
            return layer;
        }
    }

    internal class OtherLayers : IResponsible<Layer>
    {
        public bool IsResponsible(Layer layer) => !layer.OnTop();

        public Layer Handle(Layer layer)
        {
            layer.MoveUp();
            return layer;
        }
    }

    internal class VectorIsZero : IResponsible<Vector3>
    {
        public bool IsResponsible(Vector3 vector) => vector == Vector3.zero;

        public Vector3 Handle(Vector3 vector)
        {
            return Vector3.one;
        }
    }

    internal class VectorIsNormalized : IResponsible<Vector3>
    {
        public bool IsResponsible(Vector3 vector) => vector.normalized == vector;

        public Vector3 Handle(Vector3 vector)
        {
            return vector.normalized * 2;
        }
    }

    [Test]
    public void TestResponsibilityChainPattern()
    {
        // Create a new vector (this is a by value type, struct)
        Vector3 vector = new(1, 2, 3);

        // Responsibility chains for the case where the vector is zero or normalized, otherwise throw
        ResponsibilityChain<Vector3> responsibleForZero = new(new VectorIsZero());
        ResponsibilityChain<Vector3> responsibleForNormalized = new(new VectorIsNormalized());

        // Set who succeeds who
        responsibleForZero.SetSuccessor(responsibleForNormalized);

        // Due to by value, set the vector to the result
        vector = responsibleForZero.Handle(vector.normalized);
        Assert.AreEqual(vector.magnitude, 2f);

        // Let's see if we find the zero case
        vector = Vector3.zero;
        vector = responsibleForZero.Handle(vector);
        Assert.AreEqual(vector, Vector3.one);

        // Create a handler responsible for the top layer.
        ResponsibilityChain<Layer> topLayers = new(new TopLayers());

        // Create a handler responsible for the other layers.
        ResponsibilityChain<Layer> otherLayers = new(new OtherLayers());

        // If this isn't the top layer, it is probably the other layers.
        topLayers.SetSuccessor(otherLayers);

        // Make a layer and move it down
        Layer layer = new();
        layer.MoveDown();

        // The layer is not on the top, so it should get moved up by OtherLayers
        topLayers.Handle(layer);
        Assert.IsTrue(layer.OnTop());

        // The layer is now on top so it should get moved down by TopLayers
        topLayers.Handle(layer);
        Assert.IsFalse(layer.OnTop());
    }
}
