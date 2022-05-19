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
        talkData.Add(1000, new string[] {"안녕?", "여긴 연구소야" });
        talkData.Add(2000, new string[] { "안녕?", "여긴 시청이야" });
        talkData.Add(3000, new string[] { "안녕?", "여긴 정비소야" });
        talkData.Add(4000, new string[] { "안녕?", "여긴 사진관이야" });
        talkData.Add(5000, new string[] { "안녕?", "여긴 병원이야" });
        talkData.Add(6000, new string[] { "안녕?", "여긴 유치원이야" });
        talkData.Add(7000, new string[] { "안녕?", "여긴 학교야" });
        talkData.Add(8000, new string[] { "안녕?", "여긴 숙소야" });
        talkData.Add(9000, new string[] { "안녕?", "여긴 보초소야" });
        talkData.Add(10000, new string[] { "안녕?", "여긴 마을회관이야" });
        talkData.Add(11000, new string[] { "안녕?", "문제의 동상이야" });
        talkData.Add(12000, new string[] { "안녕?", "난 촌장아들이야" });
        talkData.Add(100, new string[] { "표지판 : "+"\n스트렌지 마을에 오신것을 환영합니다~",
            "표지판 : " +"촌장님은 동상 바로 옆집에 있습니다.",
            "탐정 : " +"\n 드디어 도착했네...",
            "탐정 : " + "\n 의뢰서에도 작은 산속 마을이라고 적혀있긴 해서 각오는 했지만 ",
            "탐정 : " +"\n생각보다도 더 험난했을 줄은 몰랐어...",
            "탐정 :" +"\n그럼 의뢰인인 촌장님을 만나러 가볼까?" });


        //quest talk
        talkData.Add(10+2000, new string[] { "어서오게..나는 촌장이다네:0", "요즘 마을이 어수선하여 자네를 불렀다네:1"
            , "우리 마을 사람들을 도와주면서 범인을 찾아주시게나:2"});
        talkData.Add(11 + 8000, new string[] { "어서오게..나는 촌장이다네:0", "요즘 마을이 어수선하여 자네를 불렀다네:1"
            , "우리 마을 사람들을 도와주면서 범인을 찾아주시게나:2"});
        talkData.Add(20 + 12000, new string[] { "안녕 나는 촌장 아들이야", "내가 바빠서 그런데 중요한 사진좀 찾아줄수 있을까?:1"
            , "이건 부탁이 아니라 명령이야!"});
        talkData.Add(21 + 11000, new string[] { "사진을 찾았다", "아들한테 가보자"});
        talkData.Add(22 + 12000, new string[] { "고마워 찾아줘서", "이건 답례야"});

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
