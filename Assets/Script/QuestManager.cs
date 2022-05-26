using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public int questId; //진행중인 퀘스트 아이디 유니티인스펙터에 값을 작성
    public int questActionIndex; //퀘스트대화순서 변수
    public position pos;

    Dictionary<int, QuestData> questList;  // 딕셔너리 생성

    void Awake() // 초기화
    {
        questList = new Dictionary<int, QuestData>(); // 퀘스트id , 퀘스트데이터(퀘스트 이름, npcid배열)
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()//퀘스트 저장
    {// 퀘스트아이디,퀘스트데이터 저장
  
        questList.Add(10, new QuestData("동상을 찾아보자", new int[] {11000,8000}));  
        questList.Add(20, new QuestData("왼쪽으로 가보자.. ", new int[] {5000,12000})); 
        questList.Add(30, new QuestData("촌장에게 가보자!", new int[] {2000})); 
        questList.Add(40, new QuestData("다친사람을 찾아보자", new int[] {5000})); 
        questList.Add(50, new QuestData("주변사람에게 물어보자", new int[] {3000,9000,7000})); 
        questList.Add(60, new QuestData("동상으로가보자", new int[] {6000,11000})); 
        questList.Add(70, new QuestData("사진관으로 가보자", new int[] {4000})); 
        questList.Add(80, new QuestData("아들 가보자", new int[] {12000})); 
        questList.Add(90, new QuestData("촌장을 찾으러 가자", new int[] {15000,2000})); 
       
    }
/*
연구원 / 1000
촌장 / 2000
정비소 / 3000
사진사 / 4000
의사 / 5000
유치원선생 / 6000
선생님 / 7000
슬립 / 8000
병사 / 9000
할아버지 / 10000
동상 / 11000
아들 / 12000
표지판 / 100
*/

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
        {
            if (questId == 80)
            {
                pos.poss();
            }
            NextQuest();
        }
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

}
