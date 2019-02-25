using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LottoResultItem : MonoBehaviour
{
    public int num;
    public bool bookmark;

    public Image iconBall1;
    public Image iconBall2;
    public Image iconBall3;
    public Image iconBall4;
    public Image iconBall5;
    public Image iconBall6;
    public Image iconBookmark;
    public Image iconCopy;
    public Image iconLucky;


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
    }

    public void SetInfo()
    {
        //인덱스 찾기
        index = LottoSaveData.Instance.LottoResults.FindIndex(e => e.num == num);

        fdNum = LottoSaveData.Instance.LottoResults[index].fdNum;
        fdDate = LottoSaveData.Instance.LottoResults[index].fdDate;
        fdType = LottoSaveData.Instance.LottoResults[index].fdType;

        Debug.Log(LottoSaveData.Instance.LottoResults[index].num);
        ballNum1 = LottoSaveData.Instance.LottoResults[index].fdBall1;
        ballNum2 = LottoSaveData.Instance.LottoResults[index].fdBall2;
        ballNum3 = LottoSaveData.Instance.LottoResults[index].fdBall3;
        ballNum4 = LottoSaveData.Instance.LottoResults[index].fdBall4;
        ballNum5 = LottoSaveData.Instance.LottoResults[index].fdBall5;
        ballNum6 = LottoSaveData.Instance.LottoResults[index].fdBall6;

        bookmark = LottoSaveData.Instance.LottoResults[index].fdBookmark;

        iconBall1.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum1);
        iconBall2.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum2);
        iconBall3.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum3);
        iconBall4.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum4);
        iconBall5.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum5);
        iconBall6.sprite = Resources.Load<Sprite>("Balls/ball_" + ballNum6);
    }
    public void DeleteItem()
    {
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

    public void Copy()
    {
        /*
        LottoSaveData.Instance.AddData(fdNum,
                    System.DateTime.Now.ToString("yyyy-MM-dd"),
                    0, // Type
                    lottoResult[0],
                    lottoResult[1],
                    lottoResult[2],
                    lottoResult[3],
                    lottoResult[4],
                    lottoResult[5]
                );
                */
    }

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
}
