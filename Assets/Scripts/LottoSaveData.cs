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
    public int fdNum1;
    public int fdNum2;
    public int fdNum3;
    public int fdNum4;
    public int fdNum5;
    public int fdNum6;
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


    public void AddData(int fdNum, int fdType, int fdNum1, int fdNum2, int fdNum3, int fdNum4, int fdNum5, int fdNum6)
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
            fdDate = System.DateTime.Now.ToString("yyyy-MM-dd"),
            fdType = fdType,
            fdNum1 = fdNum1,
            fdNum2 = fdNum2,
            fdNum3 = fdNum3,
            fdNum4 = fdNum4,
            fdNum5 = fdNum5,
            fdNum6 = fdNum6,

        });
        Debug.Log(LottoResults.Count);
        Save();
    }


    public void DeleteData()
    {

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
