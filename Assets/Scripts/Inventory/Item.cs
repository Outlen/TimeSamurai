using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Hairpin,
        HairpinAlt,
        Bow,
        BowAlt,
        Armor,
        ArmorAlt
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Hairpin:      return ItemAssets.Instance.hairpinSprite;
            case ItemType.HairpinAlt:   return ItemAssets.Instance.hairpinAltSprite;
            case ItemType.Bow:          return ItemAssets.Instance.bowSprite;
            case ItemType.BowAlt:       return ItemAssets.Instance.bowAltSprite;
            case ItemType.Armor:        return ItemAssets.Instance.armorSprite;
            case ItemType.ArmorAlt:     return ItemAssets.Instance.armorAltSprite;
        }

    }
    
}
