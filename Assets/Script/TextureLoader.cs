using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TextureLoaderInterface
{
    Object[] LoadTextures();
}

public class TextureLoader : TextureLoaderInterface
{
    public Object[] LoadTextures()
    {
        return Resources.LoadAll("Texture");
    }
}
