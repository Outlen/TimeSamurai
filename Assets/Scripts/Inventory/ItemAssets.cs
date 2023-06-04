using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite hairpinSprite;
    public Sprite hairpinAltSprite;
    public Sprite bowSprite;
    public Sprite bowAltSprite;
    public Sprite armorSprite;
    public Sprite armorAltSprite;
}
