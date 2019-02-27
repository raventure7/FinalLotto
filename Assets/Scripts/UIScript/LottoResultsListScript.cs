using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoResultsListScript : MonoBehaviour
{
    public GameObject lottoResult;

    public void AddItem(int num)
    {
        GameObject _item = Instantiate(lottoResult) as GameObject;
        _item.name = "LottoResultItem_" + num;
        _item.GetComponent<LottoResultItem>().num = num;
        _item.transform.SetParent(this.transform);
        _item.transform.localScale = new Vector3(1, 1, 1);

    }

    public void DeleteList()
    {
        Transform[] childList = GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }
    }

    /*
    public void DeleteItem(int num)
    {
        DeleteList();
        LottoSaveData.Instance.DeleteData(num);
        MainCanvas.Instance.numberManager.SetLottoResultList();
    }
    */
}
