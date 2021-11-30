using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] {"�ȳ�?", "���� �����Ҿ�" });
        talkData.Add(2000, new string[] { "�ȳ�?", "���� ��û�̾�" });
        talkData.Add(3000, new string[] { "�ȳ�?", "���� ����Ҿ�" });
        talkData.Add(4000, new string[] { "�ȳ�?", "���� �������̾�" });
        talkData.Add(5000, new string[] { "�ȳ�?", "���� �����̾�" });
        talkData.Add(6000, new string[] { "�ȳ�?", "���� ��ġ���̾�" });
        talkData.Add(7000, new string[] { "�ȳ�?", "���� �б���" });
        talkData.Add(8000, new string[] { "�ȳ�?", "���� ���Ҿ�" });
        talkData.Add(9000, new string[] { "�ȳ�?", "���� ���ʼҾ�" });
        talkData.Add(10000, new string[] { "�ȳ�?", "���� ����ȸ���̾�" });
        talkData.Add(11000, new string[] { "�ȳ�?", "������ �����̾�" });
        talkData.Add(100, new string[] { "��Ʈ���� ������ ���Ű��� ȯ���մϴ�~"});


        //quest talk
        talkData.Add(10 + 2000, new string[] { "�����..", "���� �����̳�", "�������� �����Գ�"});
        talkData.Add(11 + 5000, new string[] { "�������", "���� �������ø� �ǿ�." });


        talkData.Add(20 + 2000, new string[] { "����." });


        talkData.Add(30 + 3000, new string[] { "����ҿ� ���Ű��� ȯ���Ѵ�.","���� ������ �� �����...." });
        talkData.Add(31 + 7000, new string[] { "�����" });

        talkData.Add(40 + 0, new string[] { "����ƮŬ����" });

        talkData.Add(50 + 7000, new string[] { "�����" });
        talkData.Add(51 + 2000, new string[] { "�����" });

    }


    public string GetTalk(int id, int talkIndex) // 2012 
    {
        if(!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            
            }
            else
            {
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
        }
         
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
