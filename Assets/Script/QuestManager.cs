using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public int questId; //�������� ����Ʈ ���̵� ����Ƽ�ν����Ϳ� ���� �ۼ�
    public int questActionIndex; //����Ʈ��ȭ���� ����
    public position pos;

    Dictionary<int, QuestData> questList;  // ��ųʸ� ����

    void Awake() // �ʱ�ȭ
    {
        questList = new Dictionary<int, QuestData>(); // ����Ʈid , ����Ʈ������(����Ʈ �̸�, npcid�迭)
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()//����Ʈ ����
    {// ����Ʈ���̵�,����Ʈ������ ����
  
        questList.Add(10, new QuestData("������ ã�ƺ���", new int[] {11000,8000}));  
        questList.Add(20, new QuestData("�������� ������.. ", new int[] {5000,12000})); 
        questList.Add(30, new QuestData("���忡�� ������!", new int[] {2000})); 
        questList.Add(40, new QuestData("��ģ����� ã�ƺ���", new int[] {5000})); 
        questList.Add(50, new QuestData("�ֺ�������� �����", new int[] {3000,9000,7000})); 
        questList.Add(60, new QuestData("�������ΰ�����", new int[] {6000,11000})); 
        questList.Add(70, new QuestData("���������� ������", new int[] {4000})); 
        questList.Add(80, new QuestData("�Ƶ� ������", new int[] {12000})); 
        questList.Add(90, new QuestData("������ ã���� ����", new int[] {15000,2000})); 
       
    }
/*
������ / 1000
���� / 2000
����� / 3000
������ / 4000
�ǻ� / 5000
��ġ������ / 6000
������ / 7000
���� / 8000
���� / 9000
�Ҿƹ��� / 10000
���� / 11000
�Ƶ� / 12000
ǥ���� / 100
*/

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
        {
            if (questId == 80)
            {
                pos.poss();
            }
            NextQuest();
        }
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

}
