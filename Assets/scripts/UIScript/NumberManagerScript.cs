using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NumberManagerScript : MonoBehaviour
{
    public LottoResultsListScript lottoResultsListScript;

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
            number = Settings.GetNowDrawingNumber();
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
        SetLottoResultList(drawingNumber);
    }

    public void SetLottoResultList(int number)
    {
        lottoResultsListScript.DeleteList(); // 리스트 제거
        //List<LottoResult> tmpLottoResults = new List<LottoResult>();
        Debug.Log(number);
        if(LottoSaveData.Instance.LottoResults.Exists(e => e.fdNum == number))
        {
            for (int i = 0; i < LottoSaveData.Instance.LottoResults.Count; i++)
            {
                if (LottoSaveData.Instance.LottoResults[i].fdNum == number)
                {
                    //Debug.Log(LottoSaveData.Instance.LottoResults[i].num);
                    // 생성하기
                    // 생성 기준 잘 정하기. 구매 예정, 즐찾, 일반 순서
                    // 별도 리스트 생성해서 회차 번호 넣어 놓고 거기서 정렬해서 출력하면 될듯.
                    lottoResultsListScript.AddItem(LottoSaveData.Instance.LottoResults[i].num);
                }
            }
        }


    }

    public void MainSetting(int number)
    {
        if (number == 0)
        {
            drawingStatus = false;
            drawingNumber = Settings.GetNowDrawingNumber();
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
    /*
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
    */
}
