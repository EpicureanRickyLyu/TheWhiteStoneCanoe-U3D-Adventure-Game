using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance{get;private set;}
    private void Awake()
    {
        instance = this;
    }
    public Transform Fur;
    public Transform Food;
    public Sprite BowSprite;
    public Sprite ArrowsSprite;
    public Sprite HandSprite;
    public Sprite Fursprite;
    public Sprite Foodsprite;
    public Sprite Mapsprite;
    
}
