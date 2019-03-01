using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class DBManagerScript : MonoBehaviour
{

    static DBManagerScript dbManager;
    //public static DBManager Instance;
    private string URL;
    public List<Dictionary<string, object>> data;
    public bool success = false;

    public static DBManagerScript Instance
    {
        get { return dbManager; }
    }

    private void Awake()
    {
        dbManager = this;
        //Instance = this;
        URL = "http://sambong0819.cafe24.com/lotto";
        GetLottoList();
    }
    private void Start()
    {
        
    }
    public void GetLottoList()
    {
        WWWForm form = new WWWForm();
        form.AddField("Get", "test");
        resultFunction rf = new resultFunction(LottoListResult);
        StartCoroutine(ConnectManager.getInst().SendData(URL + "/GetLottoList.php", form, rf));
    }
    //로또 리스트 가져오기.
    void LottoListResult()
    {
        var list = new List<Dictionary<string, object>>();
        string[] lines = ConnectManager.getInst()._result.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        var header = lines[0].Split(',');
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            if (values.Length == 0 || values[0] == "") continue;
            var entry = new Dictionary<string, object>();
            for(var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        
        data = list;
        Settings.LottoResultData = list;
        success = true;
    }


/*
    public void AddScore()
    {

        Debug.Log("Add Score");
        today = System.DateTime.Now.ToString("yyyy-MM-dd"); // 오늘 날짜
        nowScore = PlayerPrefs.GetFloat("nowscore"); // 현재 점수
        PlayerNickname = PlayerPrefs.GetString("nickname"); // 유저 닉네임

        WWWForm form = new WWWForm();

        form.AddField("nickname", PlayerNickname);
        form.AddField("nowscore", nowScore.ToString()); //문자열로 넘김
        form.AddField("today", today);
        //Debug.Log(PlayerNickname + "/" + nowScore.ToString() + "/" + today);

        resultFunction rf = new resultFunction(DebugLog);
        StartCoroutine(ConnectManager.getInst().SendData(URL + "/addScore.php", form, rf));
    }
    public void GetTodayRankList()
    {
        today = System.DateTime.Now.ToString("yyyy-MM-dd"); // 오늘 날짜

        WWWForm form = new WWWForm();
        form.AddField("today", today);
        //resultFunction rf = new resultFunction(ResultManager.Instance.ResultTodayRankMap);
       // StartCoroutine(ConnectManager.getInst().SendData(URL + "/getTodayScoreList.php", form, rf));
    }
    // Game Scene 에서만 출력 함. 위에껀 메인(인덱스 페이지)
    public void GetTodayRankList2()
    {
        today = System.DateTime.Now.ToString("yyyy-MM-dd"); // 오늘 날짜

        WWWForm form = new WWWForm();
        form.AddField("today", today);
        //resultFunction rf = new resultFunction(ResultManager.Instance.ResultTodayRankMapUINone);
        //StartCoroutine(ConnectManager.getInst().SendData(URL + "/getTodayScoreList.php", form, rf));
    }



    public void DebugLog()
    {
        Debug.Log(ConnectManager.getInst()._result);
    }
*/

}