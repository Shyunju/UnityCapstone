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
        talkData.Add(13000, new string[] { "�ȳ�?", "��ȣ���" });
        talkData.Add(100, new string[] { "ǥ���� : "+"\n��Ʈ���� ������ ���Ű��� ȯ���մϴ�~",
            "Ž�� : " +"\n ���� ���� �����ߴ�...",
            "Ž�� : " + "\n �Ƿڼ����� ���� ��� �����̶�� �����ֱ� �ؼ� ������ ������ ",
            "Ž�� : " +"\n�������ٵ� �� �賭���� ���� ������...",
            "Ž�� :" +"\n�׷� �Ƿ����� ������� ������ ������?" });


        //quest talk
        talkData.Add(10+11000, new string[] { "Ž�� : "+"\n�̰� �̸����� ��¡�ΰ�?(�ò��ò�)", "Ž�� : "+"���ϴ°���?",
            "���� :" +" �̷� ��۳�!!!!!!!! ������� ��","Ž�� : :" + "�� ���� ���ϴ� ���� ���� ������ �ǳ�??","�߻ߺ�?"
        ,"Ž�� :" +" �̼Ҹ���?? "});
        talkData.Add(20 + 8000, new string[] { "Ž��(��ħ) : "+"\n ������ �� ��������...", "Ž��(��ħ) : "+"�����! Ȥ�� �̱ٹݿ� �����ѻ���� ���ó���?",
            "���� �ֹ� :" +"�������� �����ϰ� �������� ����� ���Ű��ƿ�!","Ž�� : " +"\n�켱 �������� �����߰ڱ�..."});
        talkData.Add(30 + 5000, new string[] { "Ž��(��ħ) : "+"\n �������� �پ���� �ƹ��� ����...", "������ : "+"�����!",});
        talkData.Add(31 + 13000, new string[] { "Ž��(��ħ) : "+"\n ������ ������ �ּż� �����մϴ�.", "������ : "+"\n�����Դϴ�.\n �׳����� ó�����ô� ���ε�? "
             ,"Ž�� : "+"\n�� ���� �� ������ ����Կ��� �Ƿڸ� �޾Ƽ� �� Ž���Դϴ�.","Ž�� : "+"\n �������� ������ ����� ��� �����ٰ� ����..."});
        talkData.Add(40 + 2000, new string[] { "���� : "+"\n ����ð� �� ������ �����̶��","����Ƶ� : "+ "�ƹ���! ���� �ƴ϶� �̺��� ��ġ�ż� ������ �°ſ���."
          ,"Ž�� : "+"\nó�� �˰ڽ��ϴ�. �Ƿڸ� �ް� �� Ž���Դϴ�."});
    }

    /*
Ž�� : ������ ����� �ּż� �����մϴ�.

���� : �����̳׿�, �׳����� ó�����ô� ���̽ŵ� ������ ���÷� ���Űǰ���? 

Ž�� : �� ���� �� ������ ����Կ��� �Ƿڸ� �޾Ƽ� �� Ž���Դϴ�. �������� ������ ����� ��� �����ٰ� ����...
*/
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
