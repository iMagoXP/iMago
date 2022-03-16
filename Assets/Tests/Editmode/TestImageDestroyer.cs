using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/*public class TestingImageDestroyer : ImageDestroyer
{
    public bool destroyed = false;
    public float yPos = 10.0f;

    override public void DestroySelf()
    {
        destroyed = true;
    }

override public float GetPositionY()
    {
        return yPos;
    }

    public void SetPositionY(float val)
    {
        yPos = val;
    }
}

public class ImageDestroyerTest
{
    [UnityTest]
    public IEnumerator Update()
    { 
        TestingImageDestroyer imageDestroyer = CreateImageDestroyerMock();

        imageDestroyer.SetPositionY(10.0f);
        imageDestroyer.Update();
        Assert.AreEqual(false, imageDestroyer.destroyed);

        imageDestroyer.SetPositionY(-10.0f);
        imageDestroyer.Update();
        Assert.AreEqual(true, imageDestroyer.destroyed);

        yield return null;
    }

    private TestingImageDestroyer CreateImageDestroyerMock()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<TestingImageDestroyer>();
    }
}
*/