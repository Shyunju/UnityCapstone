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
        talkData.Add(12000, new string[] { "�ȳ�?", "�� ����Ƶ��̾�" });
        talkData.Add(100, new string[] { "ǥ���� : "+"\n��Ʈ���� ������ ���Ű��� ȯ���մϴ�~",
            "ǥ���� : " +"������� ���� �ٷ� ������ �ֽ��ϴ�.",
            "Ž�� : " +"\n ���� �����߳�...",
            "Ž�� : " + "\n �Ƿڼ����� ���� ��� �����̶�� �����ֱ� �ؼ� ������ ������ ",
            "Ž�� : " +"\n�������ٵ� �� �賭���� ���� ������...",
            "Ž�� :" +"\n�׷� �Ƿ����� ������� ������ ������?" });


        //quest talk
        talkData.Add(10+2000, new string[] { "�����..���� �����̴ٳ�:0", "���� ������ ������Ͽ� �ڳ׸� �ҷ��ٳ�:1"
            , "�츮 ���� ������� �����ָ鼭 ������ ã���ֽðԳ�:2"});
        talkData.Add(11 + 8000, new string[] { "�����..���� �����̴ٳ�:0", "���� ������ ������Ͽ� �ڳ׸� �ҷ��ٳ�:1"
            , "�츮 ���� ������� �����ָ鼭 ������ ã���ֽðԳ�:2"});
        talkData.Add(20 + 12000, new string[] { "�ȳ� ���� ���� �Ƶ��̾�", "���� �ٺ��� �׷��� �߿��� ������ ã���ټ� ������?:1"
            , "�̰� ��Ź�� �ƴ϶� ����̾�!"});
        talkData.Add(21 + 11000, new string[] { "������ ã�Ҵ�", "�Ƶ����� ������"});
        talkData.Add(22 + 12000, new string[] { "���� ã���༭", "�̰� ��ʾ�"});

    }


    public string GetTalk(int id, int talkIndex) 
    {
        if (!talkData.ContainsKey(id))
            if (!talkData.ContainsKey(id - id % 10))
               return GetTalk(id - id % 100, talkIndex);
            else
               return GetTalk(id - id % 10, talkIndex);
         
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
