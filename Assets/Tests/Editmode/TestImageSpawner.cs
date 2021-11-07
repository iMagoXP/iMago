using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class TestImageSpawner
{
    [UnityTest]
    public IEnumerator SetTimers() //Realizar apenas quando tivermos definido os atributos serialized
    {
        ImageSpawner imageSpawner = CreateImageSpawner();


        yield return null;
    }

    [UnityTest]
    public IEnumerator LoadTextures()
    {
        ImageSpawner imageSpawner = CreateImageSpawner();
        
        {
            var stub = Substitute.For<TextureLoaderInterface>();
            stub.LoadTextures().Returns(x => null);

            imageSpawner.TestingSetterTextureLoaderInterface(stub);
            Object[] textures = imageSpawner.LoadTextures();

            Assert.AreEqual(1, textures.Length);
        }

        {
            Object[] expectedTextures = new Object[5];
            var stub = Substitute.For<TextureLoaderInterface>();
            stub.LoadTextures().Returns(x => expectedTextures);

            imageSpawner.TestingSetterTextureLoaderInterface(stub);
            Object[] textures = imageSpawner.LoadTextures();

            Assert.AreEqual(expectedTextures, textures);
        }

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

        Quaternion rot = imageSpawner.GetSpawnRotation(0);
        Assert.AreEqual(
            Quaternion.LookRotation(
               new Vector3(1.0f, 0.0f, 0.0f),
               new Vector3(0.0f, -1.0f, 0.0f)
            ),
            rot
        );
        
        rot = imageSpawner.GetSpawnRotation(5);
        Assert.AreEqual(
            Quaternion.LookRotation(
                new Vector3(0.0f, 0.0f, 1.0f),
                new Vector3(0.0f, -1.0f, 0.0f)
            ),
            rot
        );

        yield return null;
    }

    [UnityTest]
    public IEnumerator SetChildSize() 
    {
        ImageSpawner imageSpawner = CreateImageSpawner();

        for (int i = 0; i < 5; i++)
        {
            GameObject child = new GameObject();
            imageSpawner.SetChildSize(child);
            Assert.GreaterOrEqual(child.transform.localScale.x, child.transform.localScale.x * 0.5f);
            Assert.GreaterOrEqual(child.transform.localScale.y, child.transform.localScale.y * 0.5f);
            Assert.GreaterOrEqual(child.transform.localScale.z, child.transform.localScale.z * 0.5f);
            Assert.LessOrEqual(child.transform.localScale.x, child.transform.localScale.x * 2.0f);
            Assert.LessOrEqual(child.transform.localScale.y, child.transform.localScale.y * 2.0f);
            Assert.LessOrEqual(child.transform.localScale.z, child.transform.localScale.z * 2.0f);
        }

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
