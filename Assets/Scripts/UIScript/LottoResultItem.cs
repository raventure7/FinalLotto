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

    int index;
    int fdNum;
    string fdDate;
    int fdType;
    int ballNum1;
    int ballNum2;
    int ballNum3;
    int ballNum4;
    int ballNum5;
    int ballNum6;

    private void Start()
    {
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

        MainCanvas.Instance.numberManager.lottoResultsListScript.DeleteList();
        LottoSaveData.Instance.DeleteData(index);
        MainCanvas.Instance.numberManager.SetLottoResultList();
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
}
