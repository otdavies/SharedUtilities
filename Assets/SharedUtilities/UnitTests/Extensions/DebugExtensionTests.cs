using NUnit.Framework;
using Psyfer.Utilities;
using UnityEngine;

public class DebugExtensionTests
{
    [Test]
    public void PrintMultipleCommonTypes()
    {
        // Log out some primitive types
        float pi = Mathf.PI;
        string thing = "Some string here";
        Vector3 vector = new(1, 2, 3);
        pi.Log(Color.red);
        thing.Log(Color.green);
        vector.Log(Color.blue);

        // Log out some object properties
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        g.Log(Color.red);
        g.transform.Log();
        g.transform.localEulerAngles.Log();
        g.transform.localPosition.Log();

        // Log out an array
        Color[] someColors = new[] { Color.red, Color.green, Color.blue };
        someColors.Log();
    }
}
