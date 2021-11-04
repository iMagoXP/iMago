using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ImageDestroyerTest
{
    [UnityTest]
    public IEnumerator ShouldDestroy()
    { 
        ImageDestroyer imageDestroyer = CreateImageDestroyer();

        bool shouldDestroy = imageDestroyer.ShouldDestroy(0.0f);
        bool falling = imageDestroyer.TestingGetterFalling();

        Assert.AreEqual(false, falling);
        Assert.AreEqual(false, shouldDestroy);

        shouldDestroy = imageDestroyer.ShouldDestroy(180.0f);
        falling = imageDestroyer.TestingGetterFalling();

        Assert.AreEqual(true, falling);
        Assert.AreEqual(false, shouldDestroy);

        shouldDestroy = imageDestroyer.ShouldDestroy(0.0f);
        falling = imageDestroyer.TestingGetterFalling();

        Assert.AreEqual(true, falling);
        Assert.AreEqual(true, shouldDestroy);

        yield return null;
    }

    [UnityTest]
    public IEnumerator GetCurrentParentRotation()
    {
        GameObject parent = new GameObject();
        parent.transform.rotation = Quaternion.identity;

        ImageDestroyer imageDestroyer = CreateImageDestroyer();
        imageDestroyer.transform.SetParent(parent.transform);
        Quaternion parentRotation = imageDestroyer.GetCurrentParentRotation();

        Assert.AreEqual(parent.transform.rotation, parentRotation);

        yield return null;
    }

    private ImageDestroyer CreateImageDestroyer()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<ImageDestroyer>();
    }

}
