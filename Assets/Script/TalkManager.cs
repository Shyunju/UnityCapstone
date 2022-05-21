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
        talkData.Add(13000, new string[] { "안녕?", "간호사야" });
        talkData.Add(100, new string[] { "표지판 : "+"\n스트렌지 마을에 오신것을 환영합니다~",
            "탐정 : " +"\n 어휴 드디어 도착했다...",
            "탐정 : " + "\n 의뢰서에도 작은 산속 마을이라고 적혀있긴 해서 각오는 했지만 ",
            "탐정 : " +"\n생각보다도 더 험난했을 줄은 몰랐어...",
            "탐정 :" +"\n그럼 의뢰인인 촌장님을 만나러 가볼까?" });


        //quest talk
        talkData.Add(10+11000, new string[] { "탐정 : "+"\n이게 이마을의 상징인가?(시끌시끌)", "탐정 : "+"뭐하는거지?",
            "노인 :" +" 이런 써글놈!!!!!!!! 얼어죽을 놈","탐정 : :" + "저 노인 뭐하는 거지 가서 말려야 되나??","삐삐빅?"
        ,"탐정 :" +" 이소리는?? "});
        talkData.Add(20 + 8000, new string[] { "탐정(다침) : "+"\n 갑지기 왜 폭발이지...", "탐정(다침) : "+"저기요! 혹시 이근반에 수상한사람은 못봤나요?",
            "마을 주민 :" +"왼쪽으로 수상하게 도망가는 사람을 본거같아요!","탐정 : " +"\n우선 왼쪽으로 가봐야겠군..."});
        talkData.Add(30 + 5000, new string[] { "탐정(다침) : "+"\n 왼쪽으로 뛰어봐도 아무도 없어...", "누군가 : "+"저기요!",});
        talkData.Add(31 + 13000, new string[] { "탐정(다침) : "+"\n 병원에 데려다 주셔서 감사합니다.", "누군가 : "+"\n다행입니다.\n 그나저나 처음보시는 분인데? "
             ,"탐정 : "+"\n아 저는 이 마을의 촌장님에게 의뢰를 받아서 온 탐정입니다.","탐정 : "+"\n 마을에서 수상한 사건이 계속 터진다고 들어서요..."});
        talkData.Add(40 + 2000, new string[] { "촌장 : "+"\n 어서오시게 이 마을의 촌장이라네","촌장아들 : "+ "아버지! 제가 아니라 이분이 다치셔서 병원에 온거에요."
          ,"탐정 : "+"\n처음 뵙겠습니다. 의뢰를 받고 온 탐정입니다."});
    }

    /*
탐정 : 병원에 대려다 주셔서 감사합니다.

남자 : 다행이네요, 그나저나 처음보시는 분이신데 축제를 즐기시러 오신건가요? 

탐정 : 아 저는 이 마을의 촌장님에게 의뢰를 받아서 온 탐정입니다. 마을에서 수상한 사건이 계속 터진다고 들어서요...
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
