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

    public List<int> noBookmarkList = new List<int>();
    public List<Dictionary<string, object>> LottoResultData;
    public int[] lottoResult;

    // GUI
    public Text mainTitle;
    public Text mainDate;
    public Image mainPrevBtn;
    public Image mainNextBtn;

    [Header("MAIN BALL")]    
    public Text mainStatus;
    public GameObject mainBalls;
    public Image mainBall1;
    public Image mainBall2;
    public Image mainBall3;
    public Image mainBall4;
    public Image mainBall5;
    public Image mainBall6;
    public Image mainBall7;

    bool dbCheck;
    private void Awake()
    {
        dbCheck = false;
    }

    void Start()
    {
        lottoResult = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        LottoResultData = CSVReaderScript.Instance.lottoCSVData;
        SetMainGUI(0);
        drawingStatus = false;
    }



    public void SetMainGUI(int number)
    {
        if(number == 0)
        {
            number = Settings.GetNowDrawingNumber();
        }

        drawingNumber = number;
        //MainSetting(number);
        drawingDate = CSVReaderScript.Instance.dateData[drawingNumber-1]["fdEndDate"].ToString();

        mainTitle.text = drawingNumber.ToString() + "회 로또 번호 관리";
        mainDate.text = "추첨일 : "+ drawingDate.Substring(2,2)+
            "."+ drawingDate.Substring(5, 2)+"."+ drawingDate.Substring(8, 2)+" (토)";
        /*
        switch (drawingStatus)
        {
            case true:
                break;
            case false:
                mainStatus.text = "당첨 번호 미정";
                break;
        }
        */
        SetMainResult();
        SetLottoResultList();
        lottoResultsListScript.DeleteResultList();
        
    }

    public void SetMainResult()
    {
        int mainResultIndex = -1;
        if (DBManagerScript.Instance.success == true && dbCheck == false)
        {
            Debug.Log("DB 연동 완료");
            LottoResultData = Settings.LottoResultData;
            //LottoResultData = DBManagerScript.Instance.data;
            dbCheck = true;
        }

        for(int i = 0; i < LottoResultData.Count; i++)
        {
            if((int)LottoResultData[i]["fdNum"] == drawingNumber)
            {
                mainResultIndex = i;
                drawingStatus = true;
                break;
            }
            else
            {
                drawingStatus = false;
            }
        }

        if(mainResultIndex >= 0)
        {
            mainStatus.text = "";

            lottoResult[0] = (int)LottoResultData[mainResultIndex]["Num1"];
            lottoResult[1] = (int)LottoResultData[mainResultIndex]["Num2"];
            lottoResult[2] = (int)LottoResultData[mainResultIndex]["Num3"];
            lottoResult[3] = (int)LottoResultData[mainResultIndex]["Num4"];
            lottoResult[4] = (int)LottoResultData[mainResultIndex]["Num5"];
            lottoResult[5] = (int)LottoResultData[mainResultIndex]["Num6"];
            lottoResult[6] = (int)LottoResultData[mainResultIndex]["Bonus"];

            mainBall1.sprite = Resources.Load<Sprite>("Balls/ball_" + lottoResult[0]);
            mainBall2.sprite = Resources.Load<Sprite>("Balls/ball_" + lottoResult[1]);
            mainBall3.sprite = Resources.Load<Sprite>("Balls/ball_" + LottoResultData[mainResultIndex]["Num3"]);
            mainBall4.sprite = Resources.Load<Sprite>("Balls/ball_" + LottoResultData[mainResultIndex]["Num4"]);
            mainBall5.sprite = Resources.Load<Sprite>("Balls/ball_" + LottoResultData[mainResultIndex]["Num5"]);
            mainBall6.sprite = Resources.Load<Sprite>("Balls/ball_" + LottoResultData[mainResultIndex]["Num6"]);
            mainBall7.sprite = Resources.Load<Sprite>("Balls/ball_" + LottoResultData[mainResultIndex]["Bonus"]);
            mainBalls.SetActive(true);
        }
        else
        {
            mainStatus.text = "현재 당첨 번호가 없습니다.";
            mainBalls.SetActive(false);
        }

    }


    public void SetLottoResultList()
    {
        noBookmarkList.Clear();
        lottoResultsListScript.DeleteList(); // 리스트 제거
        //List<LottoResult> tmpLottoResults = new List<LottoResult>();

        if (LottoSaveData.Instance.LottoResults.Exists(e => e.fdNum == drawingNumber))
        {
            /*
            for (int i = 0; i < LottoSaveData.Instance.LottoResults.Count; i++)
            {
                if (LottoSaveData.Instance.LottoResults[i].fdNum == drawingNumber)
                {
                    // 북마크 부터 출력 하고
                    if(LottoSaveData.Instance.LottoResults[i].fdBookmark == true)
                    {
                        lottoResultsListScript.AddItem(LottoSaveData.Instance.LottoResults[i].num);
                    }
                    else
                    {
                        // 별도 리스트 넣기
                        noBookmarkList.Add(i);
                    }

                }
            }
            */
            // 북마크 노 리스트 출력
            /*
            for(int i= 0; i < noBookmarkList.Count; i++)
            {
                lottoResultsListScript.AddItem(LottoSaveData.Instance.LottoResults[noBookmarkList[i]].num);
            }
            noBookmarkList.Clear();
            */
        }

        StartCoroutine("CreateItem");
    }

    IEnumerator CreateItem()
    {
        for (int i = 0; i < LottoSaveData.Instance.LottoResults.Count; i++)
        {
            if (LottoSaveData.Instance.LottoResults[i].fdNum == drawingNumber)
            {
                // 북마크 부터 출력 하고
                if (LottoSaveData.Instance.LottoResults[i].fdBookmark == true)
                {
                    lottoResultsListScript.AddItem(LottoSaveData.Instance.LottoResults[i].num);
                    yield return new WaitForSeconds(0.01f);
                }
                else
                {
                    // 별도 리스트 넣기
                    noBookmarkList.Add(i);
                    
                }

            }
        }
        for (int i = 0; i < noBookmarkList.Count; i++)
        {
            lottoResultsListScript.AddItem(LottoSaveData.Instance.LottoResults[noBookmarkList[i]].num);
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    /*
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
    */
    /*
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
    */
    public void Prev()
    {
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
