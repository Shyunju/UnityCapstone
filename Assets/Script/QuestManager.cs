using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    //public GameObject[] questObject;

    Dictionary<int, QuestDaTA> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestDaTA>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestDaTA("촌장에게 가보자", new int[] {2000,5000}));
        questList.Add(20, new QuestDaTA("약을 가져다 주자", new int[] {2000}));
        questList.Add(30, new QuestDaTA("정비소 레츠고", new int[] {3000,7000}));
        questList.Add(40, new QuestDaTA("퀘스트클리어", new int[] {0}));
        questList.Add(50, new QuestDaTA("퀘스트클리어", new int[] {7000,2000}));
       
    }

    //1000 연구소
    //2000 촌장
    //3000 정비소
    //4000 카메라
    //5000 병원


    public int GetQuestTalkIndex(int id)
    {
        return questId+ questActionIndex;
    }


    public string CheckQuest(int id)
    {
        Debug.Log(questList[questId].npcId[questActionIndex]);

        if(questList[questId].npcId[questActionIndex] == 0)
        {
            NextQuest();
        }

        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
            //dbug.Log("인덱스조건문에 들어옴 : " +);

        }
        
        
        // ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();
        
        return questList[questId].questName;
    }
    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
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
