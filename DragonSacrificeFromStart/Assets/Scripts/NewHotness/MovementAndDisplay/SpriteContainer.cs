﻿using UnityEngine;

public class SpriteContainer : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites = null;

    public int SCNumSprites()
    {
        int i = sprites.Length;
        return i;
    }

    public Sprite GetSprite(int index)
    {
        Sprite sprite = sprites[index];
        return sprite;
    }
}
