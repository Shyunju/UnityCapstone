using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Photo,
    Camera,
    bag
}

[System.Serializable]
public class item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    public bool Use()
    {
        return false;
    }

}
