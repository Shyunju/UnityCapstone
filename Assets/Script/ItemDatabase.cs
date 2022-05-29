using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �����ͺ��̽�
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance; //�����۵����ͺ��̽��� �ν��Ͻ�

    private void Awake() // �ʱ�ȭ
    {
        instance = this;
    }

    public List<item> itemDB = new List<item>(); // ������DB ����Ʈ ����
      
    [Space(20)]

    public GameObject fieldItemPrefab; // �ʿ� �ѷ����� ������ ������Ʈ
    public Vector3[] pos;

    private void Start()
    {
        //�������� ������ ���� ���� �ʿ� �ѷ����� �Լ�
        for(int i =0; i< 8; i++)
        {
            GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[i]);
        }
    }


}
