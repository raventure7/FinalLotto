using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoResultsListScript : MonoBehaviour
{
    public GameObject lottoResult;
    public List<int> deleteResults = new List<int>();


    public void AddItem(int num)
    {
        GameObject _item = Instantiate(lottoResult) as GameObject;
        _item.name = "LottoResultItem_" + num;
        _item.GetComponent<LottoResultItem>().num = num;
        _item.transform.SetParent(this.transform);
        _item.transform.localScale = new Vector3(1, 1, 1);

    }

    public void DeleteItem(int num)
    {
        Debug.Log("아이템 삭제 : " + "LottoResultItem_" + num);
        Debug.Log("현재 아이템 삭제 대기 리스트 :" + deleteResults.Count);
        Destroy(GameObject.Find("LottoResultItem_" + num).gameObject);

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

    public void DeleteResultList()
    {
        if(deleteResults.Count >= 1)
        {
            LottoSaveData.Instance.DeleteDatas(deleteResults);
        }
        deleteResults.Clear();
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
