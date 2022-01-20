using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public item item;
    public SpriteRenderer image;

    public void SetItem(item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;
    }

    public item GetItem()
    {
        return item;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
