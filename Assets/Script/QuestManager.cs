using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    //public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("촌장에게 가보자", new int[] {2000,5000}));
       
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
