using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public item item1;
    public SpriteRenderer image;

    public void SetItem(item _item)
    {
        item1.itemName = _item.itemName;
        item1.itemImage = _item.itemImage;
        item1.itemType = _item.itemType;

        image.sprite = item1.itemImage;
    }

    public item GetItem()
    {
        return item1;
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }

}
