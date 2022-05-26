using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템타입 설정
public enum ItemType
{
    candy
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
