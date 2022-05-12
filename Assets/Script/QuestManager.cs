using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public int questId; //진행중인 퀘스트 아이디 유니티인스펙터에 값을 작성
    public int questActionIndex; //퀘스트대화순서 변수

    Dictionary<int, QuestData> questList;  // 딕셔너리 생성

    void Awake() // 초기화
    {
        questList = new Dictionary<int, QuestData>(); // 퀘스트id , 퀘스트데이터(퀘스트 이름, npcid배열)
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()//퀘스트 저장
    {
        questList.Add(10, new QuestData("촌장에게 가보자", new int[] {2000,8000})); // 퀘스트아이디,퀘스트데이터 저장
        questList.Add(20, new QuestData("아들에게 가보자", new int[] {12000,11000,12000})); // 퀘스트아이디,퀘스트데이터 저장
       
    }

    //1000 연구소
    //2000 촌장
    //3000 정비소
    //4000 카메라
    //5000 병원


    public int GetQuestTalkIndex(int id) //퀘스트인덱스 얻어오기
    {
        return questId+ questActionIndex; //(퀘스트아이디 + 퀘스트 인덱스) 값을 반환
    }


    public string CheckQuest(int id) //퀘스트 체크
    {
        if(questList[questId].npcId[questActionIndex] == 0) //퀘스트리스트에 있는 해당 퀘스트아이디의 npcid가 0이라면 다음퀘스트로
        {
            NextQuest();
        }

        if (id == questList[questId].npcId[questActionIndex]) //들어온 아이디가 npcid와 같다면 인덱스증가
        {
            questActionIndex++;
        }
        
        
        // ControlObject();

        if (questActionIndex == questList[questId].npcId.Length) //퀘스트가 완료 되면 다음 퀘스트로
            NextQuest();
        
        return questList[questId].questName; // 해당퀘스트 이름을 반환
    }
    public string CheckQuest() //퀘스트 체크
    {
        return questList[questId].questName; // 해당퀘스트 이름을 반환
    }



    void NextQuest() //다음퀘스트로 퀘스트 아이디 증가
    {
        questId += 10;
        questActionIndex = 0;
    }


    /*void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if(questActionIndex == 2)
                {
                    questObject[0].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == 1)
                {
                    questObject[0].SetActive(false);
                }
                break;
        }
    }*/

}
