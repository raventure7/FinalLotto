using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCopyScript : MonoBehaviour
{
    public int copyIndex; // 카피 번호

    public void YesClick()
    {
        Debug.Log(copyIndex);
        Copy();
        Reset();

    }
    public void NoClick()
    {
        Reset();
    }

    public void Copy()
    {
        int parentNum = LottoSaveData.Instance.LottoResults[copyIndex].num;
        int fdNum = LottoSaveData.Instance.LottoResults[copyIndex].fdNum;
        string fdDate = LottoSaveData.Instance.LottoResults[copyIndex].fdDate;
        int fdType = LottoSaveData.Instance.LottoResults[copyIndex].fdType;
        int ballNum1 = LottoSaveData.Instance.LottoResults[copyIndex].fdBall1;
        int ballNum2 = LottoSaveData.Instance.LottoResults[copyIndex].fdBall2;
        int ballNum3 = LottoSaveData.Instance.LottoResults[copyIndex].fdBall3;
        int ballNum4 = LottoSaveData.Instance.LottoResults[copyIndex].fdBall4;
        int ballNum5 = LottoSaveData.Instance.LottoResults[copyIndex].fdBall5;
        int ballNum6 = LottoSaveData.Instance.LottoResults[copyIndex].fdBall6;
        bool bookmark = LottoSaveData.Instance.LottoResults[copyIndex].fdBookmark;
        bool lucky = LottoSaveData.Instance.LottoResults[copyIndex].fdLucky;

        LottoSaveData.Instance.AddData(fdNum + 1,
                    fdDate,
                    fdType, // Type
                    ballNum1,
                    ballNum2,
                    ballNum3,
                    ballNum4,
                    ballNum5,
                    ballNum6,
                    bookmark,
                    lucky,
                    parentNum
                );

        hiddenIcon(parentNum);
    }
    public void hiddenIcon(int parentNum)
    {
        GameObject.Find("LottoResultItem_" + parentNum).GetComponent<LottoResultItem>().SetCopy();
        Debug.Log(GameObject.Find("LottoResultItem_" + parentNum).name);
        // 컴포넌트에서 네임으로 해당 이름 값을 조회한 후 강제로 변경
    }




    public void Reset()
    {
        SetActive(false);
    }
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
