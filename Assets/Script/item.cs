using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ÿ�� ����
public enum ItemType
{
    candy
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
