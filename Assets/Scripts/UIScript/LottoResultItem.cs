using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LottoResultItem : MonoBehaviour
{
    public int num;
    public bool bookmark;
    public bool lucky;
    public bool copy;

    public Image iconBall1;
    public Image iconBall2;
    public Image iconBall3;
    public Image iconBall4;
    public Image iconBall5;
    public Image iconBall6;
    public Image iconBookmark;
    public Image iconCopy;
    public Image iconLucky;
    public Text textType;
    public GameObject objRank;
    public Text textRank;
    

    public int index;

    int fdNum;
    string fdDate;
    int fdType;
    int ballNum1;
    int ballNum2;
    int ballNum3;
    int ballNum4;
    int ballNum5;
    int ballNum6;

    int prizeCount;

    private void Start()
    {
        //this.gameObject.SetActive(false);
        SetInfo();
        SetBookmarkIcon();
        SetLuckyIcon();
        SetCopyIcon();
        SetTypeText();
    }

    public void SetInfo()
    {

        //인덱스 찾기
        index = LottoSaveData.Instance.LottoResults.FindIndex(e => e.num == num);

        fdNum = LottoSaveData.Instance.LottoResults[index].fdNum;
        fdDate = LottoSaveData.Instance.LottoResults[index].fdDate;
        fdType = LottoSaveData.Instance.LottoResults[index].fdType;

        //Debug.Log(LottoSaveData.Instance.LottoResults[index].num);
        ballNum1 = LottoSaveData.Instance.LottoResults[index].fdBall1;
        ballNum2 = LottoSaveData.Instance.LottoResults[index].fdBall2;
        ballNum3 = LottoSaveData.Instance.LottoResults[index].fdBall3;
        ballNum4 = LottoSaveData.Instance.LottoResults[index].fdBall4;
        ballNum5 = LottoSaveData.Instance.LottoResults[index].fdBall5;
        ballNum6 = LottoSaveData.Instance.LottoResults[index].fdBall6;

        bookmark = LottoSaveData.Instance.LottoResults[index].fdBookmark;
        copy = LottoSaveData.Instance.LottoResults[index].fdCopy;

        iconBall1.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum1);
        iconBall2.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum2);
        iconBall3.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum3);
        iconBall4.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum4);
        iconBall5.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum5);
        iconBall6.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum6);

        {
            iconBall1.color = new Color32(255, 255, 255, 80);
            iconBall2.color = new Color32(255, 255, 255, 80);
            iconBall3.color = new Color32(255, 255, 255, 80);
            iconBall4.color = new Color32(255, 255, 255, 80);
            iconBall5.color = new Color32(255, 255, 255, 80);
            iconBall6.color = new Color32(255, 255, 255, 80);
        }

        if (MainCanvas.Instance.numberManager.drawingStatus == true)
        {
            prizeCount = 0;
            int count = MainCanvas.Instance.numberManager.lottoResult.Length-1;
            for(int i =0; i< count; i++)
            {
                if (MainCanvas.Instance.numberManager.lottoResult[i] == ballNum1)
                {
                    iconBall1.color = new Color32(255, 255, 255, 255);
                    prizeCount++;
                }
                if (MainCanvas.Instance.numberManager.lottoResult[i] == ballNum2)
                {
                    iconBall2.color = new Color32(255, 255, 255, 255);
                    prizeCount++;
                }
                if (MainCanvas.Instance.numberManager.lottoResult[i] == ballNum3)
                {
                    iconBall3.color = new Color32(255, 255, 255, 255);
                    prizeCount++;
                }
                if (MainCanvas.Instance.numberManager.lottoResult[i] == ballNum4)
                {
                    iconBall4.color = new Color32(255, 255, 255, 255);
                    prizeCount++;
                }
                if (MainCanvas.Instance.numberManager.lottoResult[i] == ballNum5)
                {
                    iconBall5.color = new Color32(255, 255, 255, 255);
                    prizeCount++;
                }
                if (MainCanvas.Instance.numberManager.lottoResult[i] == ballNum6)
                {
                    iconBall6.color = new Color32(255, 255, 255, 255);
                    prizeCount++;
                }

                if(prizeCount == 5)
                {
                    if (MainCanvas.Instance.numberManager.lottoResult[6] == ballNum1)
                    {
                        iconBall1.color = new Color32(255, 255, 255, 255);
                        prizeCount++;
                    }
                    if (MainCanvas.Instance.numberManager.lottoResult[6] == ballNum2)
                    {
                        iconBall2.color = new Color32(255, 255, 255, 255);
                        prizeCount++;
                    }
                    if (MainCanvas.Instance.numberManager.lottoResult[6] == ballNum3)
                    {
                        iconBall3.color = new Color32(255, 255, 255, 255);
                        prizeCount++;
                    }
                    if (MainCanvas.Instance.numberManager.lottoResult[6] == ballNum4)
                    {
                        iconBall4.color = new Color32(255, 255, 255, 255);
                        prizeCount++;
                    }
                    if (MainCanvas.Instance.numberManager.lottoResult[6] == ballNum5)
                    {
                        iconBall5.color = new Color32(255, 255, 255, 255);
                        prizeCount++;
                    }
                    if (MainCanvas.Instance.numberManager.lottoResult[6] == ballNum6)
                    {
                        iconBall6.color = new Color32(255, 255, 255, 255);
                        prizeCount++;
                    }
                }
                
            }
            if(prizeCount < 2 && bookmark == false)
            {
                this.gameObject.SetActive(false);
                
                if (!MainCanvas.Instance.numberManager.lottoResultsListScript.deleteResults.Contains(num))
                {
                   MainCanvas.Instance.numberManager.lottoResultsListScript.deleteResults.Add(num);
                }
                

            }

            if(prizeCount >= 3)
            {
                this.GetComponent<Image>().color = new Color32(206, 217, 255, 255);
                objRank.SetActive(true);
                switch(prizeCount)
                {
                    case 3:
                        textRank.text = "5등";
                        break;
                    case 4:
                        textRank.text = "4등";
                        break;
                    case 5:
                        textRank.text = "3등";
                        break;
                    case 6:
                        textRank.text = "2등";
                        break;
                }
            }
            else
            {
                objRank.SetActive(false);
            }
        }
        else
        {
            iconBall1.color = new Color32(255, 255, 255, 255);
            iconBall2.color = new Color32(255, 255, 255, 255);
            iconBall3.color = new Color32(255, 255, 255, 255);
            iconBall4.color = new Color32(255, 255, 255, 255);
            iconBall5.color = new Color32(255, 255, 255, 255);
            iconBall6.color = new Color32(255, 255, 255, 255);
        }

    }
    public void DeleteItem()
    {
        int parentNum = LottoSaveData.Instance.LottoResults[index].fdParentNum;
        if(parentNum != -1)
        {
            //삭제시 파렌트 번호 조회해서, 부모 복사 활성화 시켜주기.
            int parentIndex = LottoSaveData.Instance.LottoResults.FindIndex(e => e.num == parentNum);
            if(parentIndex >= 0)
            { LottoSaveData.Instance.UpdateData(parentIndex, "copy", false);
            }
        }
        MainCanvas.Instance.numberManager.lottoResultsListScript.DeleteItem(num); // UI삭제
        LottoSaveData.Instance.DeleteData(index); //리스트 삭제
        if(MainCanvas.Instance.numberManager.lottoResultsListScript.deleteResults.Count >= 1)
        {
            Debug.Log("삭제 대기리스트 존재 : " + MainCanvas.Instance.numberManager.lottoResultsListScript.deleteResults.Count);
        }


        //MainCanvas.Instance.numberManager.lottoResultsListScript.DeleteList();
        //MainCanvas.Instance.numberManager.SetLottoResultList();
    }

   
    public void SetBookmark()
    {
        if(bookmark == false)
        {
            bookmark = true;
            LottoSaveData.Instance.UpdateData(index, "bookmark", bookmark);
        }
        else
        {
            bookmark = false;
            LottoSaveData.Instance.UpdateData(index, "bookmark", bookmark);
        }
        SetBookmarkIcon();
    }
    public void SetLucky()
    {
        if (lucky == false)
        {
            lucky = true;
            LottoSaveData.Instance.UpdateData(index, "lucky", lucky);
        }
        /*
        else
        {
            lucky = false;
            LottoSaveData.Instance.UpdateData(index, "lucky", lucky);
        }
        */
        SetLuckyIcon();
    }

    public void AlertCopy()
    {
        if(copy == false)
        {
            AlertMessageScript.Instance.ViewCopy(index);
        }
    }

    public void AlertAnalysis()
    {
        AlertMessageScript.Instance.ViewAnalysis(index);
    }

    public void SetCopy()
    {
        if(copy == false)
        {
            copy = true;
            LottoSaveData.Instance.UpdateData(index, "copy", copy);
        }
        SetCopyIcon();
    }

    /*
    public void Copy()
    {
        LottoSaveData.Instance.AddData(fdNum,
                    fdDate,
                    fdType, // Type
                    ballNum1,
                    ballNum2,
                    ballNum3,
                    ballNum4,
                    ballNum5,
                    ballNum6,
                    bookmark,
                    lucky
                );
    }
    */


    public void SetBookmarkIcon()
    {
        if(bookmark == true)
        {
            iconBookmark.color = new Color32(255, 248, 0, 255);
        }
        else
        {
            iconBookmark.color = new Color32(255, 255, 255, 255);
        }
    }

    public void SetLuckyIcon()
    {
        if (lucky == true)
        {
            iconLucky.color = new Color32(255, 248, 0, 255);
        }
        else
        {
            iconLucky.color = new Color32(255, 255, 255, 255);
        }
    }
    public void SetCopyIcon()
    {
        if(copy == true)
        {
            iconCopy.color = new Color32(255, 255, 255, 255);

        }
        else
        {
            iconCopy.color = new Color32(149, 231, 56, 255);
        }
    }
    public void SetTypeText()
    {
        string str = "";
        switch (fdType)
        {
            case 0:
                str = "추천번호";
                break;
        }
        textType.text = fdDate.Substring(5,2)+"."+ fdDate.Substring(8, 2) + " " + str;
    }

    public void Delete()
    {
        if(prizeCount < 2 && bookmark == false)
        {
            MainCanvas.Instance.numberManager.lottoResultsListScript.DeleteItem(num);
            LottoSaveData.Instance.DeleteData(index);
        }
    }
}
