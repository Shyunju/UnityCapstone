using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ÿ�� ����
public enum ItemType
{
    pic1,
    pic2,pic3,pic4,pic5,pic6,pic7,pic8
}

[System.Serializable]

//������ Ŭ����
public class item
{
    public ItemType itemType; // ������ Ÿ��
    public string itemName; //������ �̸�
    public Sprite itemImage; // ������ �̹���

    public bool Use() //��������� �ƴ��� Ȯ��
    {
        return false;
    }

}
