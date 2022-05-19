using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public QuestManager questManager;
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public GameObject next;
    public statue statue;

    void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj)
    {
        
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
            talkPanel.SetActive(isAction);
            next.SetActive(isAction);
    }


    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);

        if(talkData == null)//대화가 끝나면
        {
            if (id == 11000)
            {
                statue.Bomb();
            }
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);//퀘스트 순번 증가
            Debug.Log(questManager.CheckQuest(id)); 
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;
              
        }
        else
        {
            talkText.text = talkData;
        }
        
        isAction = true;
        talkIndex++;
    }
}
