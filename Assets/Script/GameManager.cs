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

        if(talkData == null)//��ȭ�� ������
        {
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);//����Ʈ ���� ����
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
