using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestImageSpawner
{
    [UnityTest]
    public IEnumerator SetTimers() //Realizar apenas quando tivermos definido os atributos serialized
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator GetCurrentCooldown() //Realizar depois
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator SpawnImage() //Realizar depois
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator GetSpawnRow() //Realizar depois
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator GetSpawnPosition()
    {
        // TODO: usar atributos ao invés de números mágicos
        ImageSpawner imageSpawner = CreateImageSpawner();

        Vector3 position = imageSpawner.GetSpawnPosition(0);
        Assert.AreEqual(imageSpawner.transform.position, position);

        position = imageSpawner.GetSpawnPosition(1);
        Vector3 pos = imageSpawner.transform.position;   
        Assert.AreEqual(new Vector3(pos.x, pos.y + 0.016f, pos.z + 2), position);
        
        for(int i = 0; i < 5; i++)
        {
            position = imageSpawner.GetSpawnPosition(5);
            pos = imageSpawner.transform.position;
            Assert.AreEqual(pos.x, position.x);
            Assert.GreaterOrEqual(pos.y + 2.5f, position.y);
            Assert.LessOrEqual(pos.y + 1.5f, position.y);
            Assert.GreaterOrEqual(pos.z + 11.0f, position.z);
            Assert.LessOrEqual(pos.z + 9.0f, position.z);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator GetSpawnRotation() 
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator SetChildSize() 
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator SetChildTexture() //Realizar depois
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    private ImageSpawner CreateImageSpawner()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<ImageSpawner>();
    }
}
