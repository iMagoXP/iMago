using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class TestingImageSpawner : ImageSpawner
{
    // Testing getters

    public float GetBaseImagesPerSecond()
    {
        return baseImagesPerSecond;
    }

    public float GetImagesPerSecond()
    {
        return imagesPerSecond;
    }

    public float GetSpawnTimer()
    {
        return spawnTimer;
    }

    public float GetImageLevelTimer() 
    {
        return imageLevelTimer;
    }
    
    public int GetRowCount()
    {
        return rowCount;
    }
    
    // Testing setters

    public void SetTextureLoaderInterface(TextureLoaderInterface inter)
    {
        textureLoader = inter;
    }
}

public class ImageSpawnerUpdateMock : TestingImageSpawner
{
    public bool didSpawnImage = false;
    public float dt;

    public ImageSpawnerUpdateMock()
    {
        imagesPerSecond = 10.0f;
        imageLevelCooldown = 5.0f;
        imagesPerSecondIncrement = 3.0f;
    }

    public override void SpawnImage()
    {
        didSpawnImage = true;
    }

    public override void SetChildSize(GameObject child)
    {
        child.transform.localScale *= 1;
    }

    public override float GetDeltaTime()
    {
        return dt;
    }
}

public class TestImageSpawner
{
    [UnityTest]
    public IEnumerator Update()
    {
        {
            GameObject gameObject = new GameObject();
            ImageSpawnerUpdateMock imageSpawner = gameObject.AddComponent<ImageSpawnerUpdateMock>();

            imageSpawner.dt = 0.0f;

            imageSpawner.Update();
            Assert.AreEqual(0.0f, imageSpawner.GetImageLevelTimer());
            Assert.AreEqual(false, imageSpawner.didSpawnImage);
            Assert.AreEqual(0.0f, imageSpawner.GetSpawnTimer());
            Assert.AreEqual(1.0f/10.0f, imageSpawner.GetSpawnCooldown());
        }

        {
            ImageSpawnerUpdateMock imageSpawner = CreateImageSpawnerMock();

            imageSpawner.dt = 10.0f;

            imageSpawner.Update();
            Assert.AreEqual(0.0f, imageSpawner.GetImageLevelTimer());
            Assert.AreEqual(13.0f, imageSpawner.GetImagesPerSecond());
            Assert.AreEqual(true, imageSpawner.didSpawnImage);
            Assert.AreEqual(10.0f-(1.0f / 13.0f), imageSpawner.GetSpawnTimer());
            Assert.AreEqual(1.0f/13.0f, imageSpawner.GetSpawnCooldown());
        }

        yield return null;
    }

   [UnityTest]
    public IEnumerator SetTimers()
    {
        var imageSpawner = CreateImageSpawner();
        float imagesPerSecond = imageSpawner.GetBaseImagesPerSecond();
        imageSpawner.SetTimers();
        Assert.AreEqual(imagesPerSecond, imageSpawner.GetImagesPerSecond());
        Assert.AreEqual(imageSpawner.GetSpawnCooldown(), imageSpawner.GetSpawnTimer());

        yield return null;
    }

    [UnityTest]
    public IEnumerator LoadTextures()
    {
        var imageSpawner = CreateImageSpawner();
        
        {
            var stub = Substitute.For<TextureLoaderInterface>();
            stub.LoadTextures().Returns(x => null);

            imageSpawner.SetTextureLoaderInterface(stub);
            Object[] textures = imageSpawner.LoadTextures();

            Assert.AreEqual(1, textures.Length);
        }

        {
            Object[] expectedTextures = new Object[5];
            var stub = Substitute.For<TextureLoaderInterface>();
            stub.LoadTextures().Returns(x => expectedTextures);

            imageSpawner.SetTextureLoaderInterface(stub);
            Object[] textures = imageSpawner.LoadTextures();

            Assert.AreEqual(expectedTextures, textures);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator GetSpawnRow()
    {
        var imageSpawner = CreateImageSpawner();

        int maxRow = imageSpawner.GetRowCount();
        int minRow = -maxRow;

        for (int i = 0; i < 5; i++)
        {
            var lane = imageSpawner.GetSpawnRow();
            Assert.LessOrEqual(minRow, lane);
            Assert.GreaterOrEqual(maxRow, lane);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator GetSpawnPosition()
    {
        // TODO: usar atributos ao inv�s de n�meros m�gicos
        var imageSpawner = CreateImageSpawner();

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
        var imageSpawner = CreateImageSpawner();

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
        var imageSpawner = CreateImageSpawnerMock();

        for (int i = 0; i < 5; i++)
        {
            GameObject child = new GameObject();
            imageSpawner.SetChildSize(child);
            Assert.GreaterOrEqual(child.transform.localScale.x, child.transform.localScale.x * 1);
            Assert.GreaterOrEqual(child.transform.localScale.y, child.transform.localScale.y * 1);
            Assert.GreaterOrEqual(child.transform.localScale.z, child.transform.localScale.z * 1);
            Assert.LessOrEqual(child.transform.localScale.x, child.transform.localScale.x * 1);
            Assert.LessOrEqual(child.transform.localScale.y, child.transform.localScale.y * 1);
            Assert.LessOrEqual(child.transform.localScale.z, child.transform.localScale.z * 1);
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator SetChildTexture() // TODO: Perguntar para os professores
    {
        var imageSpawner = CreateImageSpawner();


        yield return null;
    }

    private TestingImageSpawner CreateImageSpawner()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<TestingImageSpawner>();
    }

    private ImageSpawnerUpdateMock CreateImageSpawnerMock()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<ImageSpawnerUpdateMock>();
    }
}