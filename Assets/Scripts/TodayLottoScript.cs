using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class TodayLottoScript : MonoBehaviour
{
    public int[] lottoResult;
    private void Awake()
    {
        lottoResult = new int[6] { 0, 0, 0, 0, 0, 0 };
        
    }
    private void Start()
    {
        /*
        LottoSaveData.Instance.Clear();
        for (int i = 0; i < 5; i++)
        {
            CreateLotto();
        }
        */
        string nowDate = Settings.GetNowDate();
        if (PlayerPrefs.GetString("NowDate") != nowDate)
        {
            for(int i = 0; i < 5; i++)
            {
                CreateLotto();
            }
            PlayerPrefs.SetString("NowDate", nowDate);
        }
    }



    void CreateLotto()
    {
        bool check = true;
        lottoResult = new int[6] { 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i<= 5; i++)
        {
            check = true;
            int rnd = Random.Range(1, 45);
            for(int j = 0; j <= lottoResult.Length -1; j++)
            {
                if(lottoResult[j] == rnd)
                {
                    i--;
                    check = false;
                    break;
                }
            }

            if(check == true)
                lottoResult[i] = rnd;
        }

        int k = 0;
        foreach (int sort in lottoResult.OrderBy(sorted => sorted))
        {
            lottoResult[k++] = sort;
        }
        int fdNum = Settings.GetNowDrawingNumber(); // 현재 회차 정보

        
        LottoSaveData.Instance.AddData(fdNum,
            System.DateTime.Now.ToString("yyyy-MM-dd"),
            0, // Type
            lottoResult[0],
            lottoResult[1],
            lottoResult[2],
            lottoResult[3],
            lottoResult[4],
            lottoResult[5],
            false,
            false,
            -1
        );
    }

}
