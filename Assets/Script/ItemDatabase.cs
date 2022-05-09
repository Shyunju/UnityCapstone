using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템 데이터베이스
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance; //아이템데이터베이스의 인스턴스

    private void Awake() // 초기화
    {
        instance = this;
    }

    public List<item> itemDB = new List<item>(); // 아이템DB 리스트 생성
      
    [Space(20)]

    public GameObject fieldItemPrefab; // 맵에 뿌려지는 아이템 오브젝트
    public Vector3[] pos;

    private void Start()
    {
        //아이템이 포지션 값에 따라 맵에 뿌려지는 함수
        for(int i =0; i< 5; i++)
        {
            GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0,3)]);
        }
    }


}
