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
        talkData.Add(2000 + 10, new string[] { "�����..���� �����̴ٳ�", "���� ������ ������Ͽ� �ڳ׸� �ҷ��ٳ�"
            , "�츮 ���� ������� �����ָ鼭 ������ ã���ֽðԳ�"});


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
