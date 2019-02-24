using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings{
    
    // 현재 회차 정보 가져오기
    public static int GetNowDrawingNumber()
    {
        string nowDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        int intNowDate = int.Parse(nowDate.Replace("-", ""));
        for (int i = 800; i < CSVReaderScript.Instance.dateData.Count; i++)
        {
            int fdEndDate = int.Parse(CSVReaderScript.Instance.dateData[i]["fdEndDate"].ToString().Replace("-", ""));
            if (intNowDate <= fdEndDate)
            {
                return int.Parse(CSVReaderScript.Instance.dateData[i]["fdNum"].ToString());
            }
        }
        return 0;
    }

    public static string GetNowDate()
    {
        return System.DateTime.Now.ToString("yyyy-MM-dd");
    }

}
