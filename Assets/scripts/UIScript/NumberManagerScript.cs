using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumberManagerScript : MonoBehaviour
{
    public string nowDate;
    public int drawingNumber; // 회차 정보
    public string drawingDate; //   추첨일
    public bool drawingStatus;

    // GUI
    public Text mainTitle;
    public Text mainDate;
    public Text mainStatus;
    public Image mainPrevBtn;
    public Image mainNextBtn;

    // Start is called before the first frame update
    void Start()
    {
        SetMainGUI(0);
        drawingStatus = true;
    }



    public void SetMainGUI(int number)
    {
        if(number == 0)
        {
            number = GetNowDrawingNumber();
            drawingStatus = false;
        }
        drawingNumber = number;
        //MainSetting(number);
        drawingDate = CSVReaderScript.Instance.dateData[drawingNumber]["fdEndDate"].ToString();

        mainTitle.text = drawingNumber.ToString() + "회 로또 번호 관리";
        mainDate.text = "추첨일 ("+drawingDate+")";
        switch(drawingStatus)
        {
            case true:
                break;
            case false:
                mainStatus.text = "당첨 번호 미정";
                break;
        }
    }

    public void MainSetting(int number)
    {
        if (number == 0)
        {
            drawingStatus = false;
            drawingNumber = GetNowDrawingNumber();
        }
        else
        {
            drawingStatus = true;
        }
    }

    public void Prev()
    {
        Debug.Log("이전 클릭");
        SetMainGUI(drawingNumber - 1);
    }
    public void Next()
    {
        SetMainGUI(drawingNumber + 1);
    }

    //현재 회차 가져오기
    public int GetNowDrawingNumber()
    {
        nowDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        int intNowDate = int.Parse(nowDate.Replace("-", ""));
        for (int i = 800; i < CSVReaderScript.Instance.dateData.Count; i++)
        {
            int fdEndDate = int.Parse(CSVReaderScript.Instance.dateData[i]["fdEndDate"].ToString().Replace("-", ""));
            if (intNowDate <= fdEndDate)
            {
                return int.Parse(CSVReaderScript.Instance.dateData[i]["fdNum"].ToString()) -1;
            }
        }
        return 0;
    }
}
