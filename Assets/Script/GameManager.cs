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
    public Image Illust;


    void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Action(GameObject scanObj)  //오브젝트 ID NPC여부 데이터 대화창뜨는 메서드
    {
        
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
            talkPanel.SetActive(isAction);
            next.SetActive(isAction); 
    }


    void Talk(int id, bool isNpc) //토크 메서드
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
            Illust.sprite = talkManager.Getillust(id);

            Illust.color = new Color(1, 1, 1, 1);
              
        }
        else
        {
            talkText.text = talkData;

            Illust.color = new Color(1, 1, 1, 0);
        }
        
        isAction = true;
        talkIndex++;
    }
}
