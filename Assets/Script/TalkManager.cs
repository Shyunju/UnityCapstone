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
        talkData.Add(100, new string[] { "스트렌지 마을에 오신것을 환영합니다~"});


        //quest talk
        talkData.Add(2000 + 10, new string[] { "어서오게..나는 촌장이다네", "요즘 마을이 어수선하여 자네를 불렀다네"
            , "우리 마을 사람들을 도와주면서 범인을 찾아주시게나"});


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
