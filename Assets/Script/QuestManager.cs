using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public int questId; //�������� ����Ʈ ���̵� ����Ƽ�ν����Ϳ� ���� �ۼ�
    public int questActionIndex; //����Ʈ��ȭ���� ����

    Dictionary<int, QuestData> questList;  // ��ųʸ� ����

    void Awake() // �ʱ�ȭ
    {
        questList = new Dictionary<int, QuestData>(); // ����Ʈid , ����Ʈ������(����Ʈ �̸�, npcid�迭)
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()//����Ʈ ����
    {
        questList.Add(10, new QuestData("���忡�� ������", new int[] {2000,8000})); // ����Ʈ���̵�,����Ʈ������ ����
        questList.Add(20, new QuestData("�Ƶ鿡�� ������", new int[] {12000,11000,12000})); // ����Ʈ���̵�,����Ʈ������ ����
       
    }

    //1000 ������
    //2000 ����
    //3000 �����
    //4000 ī�޶�
    //5000 ����


    public int GetQuestTalkIndex(int id) //����Ʈ�ε��� ������
    {
        return questId+ questActionIndex; //(����Ʈ���̵� + ����Ʈ �ε���) ���� ��ȯ
    }


    public string CheckQuest(int id) //����Ʈ üũ
    {
        if(questList[questId].npcId[questActionIndex] == 0) //����Ʈ����Ʈ�� �ִ� �ش� ����Ʈ���̵��� npcid�� 0�̶�� ��������Ʈ��
        {
            NextQuest();
        }

        if (id == questList[questId].npcId[questActionIndex]) //���� ���̵� npcid�� ���ٸ� �ε�������
        {
            questActionIndex++;
        }
        
        
        // ControlObject();

        if (questActionIndex == questList[questId].npcId.Length) //����Ʈ�� �Ϸ� �Ǹ� ���� ����Ʈ��
            NextQuest();
        
        return questList[questId].questName; // �ش�����Ʈ �̸��� ��ȯ
    }
    public string CheckQuest() //����Ʈ üũ
    {
        return questList[questId].questName; // �ش�����Ʈ �̸��� ��ȯ
    }



    void NextQuest() //��������Ʈ�� ����Ʈ ���̵� ����
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
