using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class LottoResult
{
    public int num;
    public int fdNum;
    public string fdDate;
    public int fdType;
    public int fdBall1;
    public int fdBall2;
    public int fdBall3;
    public int fdBall4;
    public int fdBall5;
    public int fdBall6;
    public bool fdBookmark;
    public bool fdCopy;
    public bool fdLucky;
    public int fdRank;
    public int fdParentNum;
}

public class LottoSaveData : MonoBehaviour
{

    static LottoSaveData lottoSaveData;
    public static LottoSaveData Instance
    {
        get { return lottoSaveData; }
    }

    public List<LottoResult> LottoResults = new List<LottoResult>();

    public void Awake()
    {
        lottoSaveData = this;
        Load();
    }
    public void Save()
    {
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, LottoResults);
        PlayerPrefs.SetString("SaveData", Convert.ToBase64String(memoryStream.GetBuffer()));
        // 세이브 시에는 CSV 까지 저장
        Load();
    }


    public void Load()
    {
        var saveData = PlayerPrefs.GetString("SaveData");
        if (!string.IsNullOrEmpty(saveData))
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream(Convert.FromBase64String(saveData));

            //가져온 데이터를 다시 바이트 배열 변환
            //사용하기 위해 다시 리스트로 캐스팅
            LottoResults = (List<LottoResult>)binaryFormatter.Deserialize(memoryStream);
        }
        else
        {
            LottoResults = new List<LottoResult>();
        }
    }


    public void AddData(int fdNum, string fdDate, int fdType, int fdNum1, int fdNum2, int fdNum3, int fdNum4, int fdNum5, int fdNum6, bool fdBookmark, bool fdLucky, int fdParentNum)
    {
        // fdType 0 : 오늘의 추천
        int lastNum = 0;
        if (LottoResults.Count != 0)
        {
            lastNum = LottoResults.Count + 1;
        }
        LottoResults.Add(new LottoResult
        {
            num = lastNum,
            fdNum = fdNum,
            fdDate = fdDate, 
            fdType = fdType,
            fdBall1 = fdNum1,
            fdBall2 = fdNum2,
            fdBall3 = fdNum3,
            fdBall4 = fdNum4,
            fdBall5 = fdNum5,
            fdBall6 = fdNum6,
            fdBookmark = fdBookmark,
            fdCopy = false,
            fdLucky = fdLucky,
            fdRank = 0,
            fdParentNum = fdParentNum
        });
        Debug.Log(LottoResults.Count);
        Save();
    }


    public void DeleteData(int index)
    {
        //int index = LottoResults.FindIndex(e => e.num == num);
        LottoResults.Remove(LottoResults[index]);

        Save();
    }

    public void UpdateData(int index, string type, bool value)
    {
        
        switch (type)
        {
            case "bookmark":
                LottoResults[index].fdBookmark = value;
                break;
            case "lucky":
                LottoResults[index].fdLucky = value;
                break;
            case "copy":
                LottoResults[index].fdCopy = value;
                break;
        }
        Save();
    }

    public void Clear()
    {
        LottoResults.Clear();
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, LottoResults);
        PlayerPrefs.SetString("SaveData", Convert.ToBase64String(memoryStream.GetBuffer()));
    }
}
