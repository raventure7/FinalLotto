using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoResultItem : MonoBehaviour
{
    public int num;
    private void Start()
    {
        SetInfo();
    }

    public void SetInfo()
    {
        //인덱스 찾기
        int index = LottoSaveData.Instance.LottoResults.FindIndex(e => e.num == num);
        Debug.Log(LottoSaveData.Instance.LottoResults[index].num);
    }
}
