using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템타입 설정
public enum ItemType
{
    pic1,
    pic2,pic3,pic4,pic5,pic6,pic7,pic8
}

[System.Serializable]

//아이템 클래스
public class item
{
    public ItemType itemType; // 아이템 타입
    public string itemName; //아이템 이름
    public Sprite itemImage; // 아이템 이미지

    public bool Use() //사용중인지 아닌지 확인
    {
        return false;
    }

}
