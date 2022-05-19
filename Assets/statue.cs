using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statue : MonoBehaviour
{
    private SpriteRenderer image;
    public Sprite changedImage;
   

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }
    public void Bomb()
    {
        image.sprite = changedImage;
    }
}
