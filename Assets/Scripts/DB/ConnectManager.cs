using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void resultFunction();

public class ConnectManager : MonoBehaviour
{

    private static ConnectManager inst;

    public static ConnectManager getInst()
    {
        if (inst == null)
        {
            //inst = new ConnectManager();
            inst = (ConnectManager)FindObjectOfType(typeof(ConnectManager));
            inst.InitSetting();
        }
        return inst;
    }

    private Dictionary<string, string> hsHeader;
    private string result;
    public string _result
    {
        get
        {
            return result;
        }
    }
    /*
    public void Init()
    {
        inst = gameObject.AddComponent<ConnectManager>();
    }
    */
    public void InitSetting()
    {

        hsHeader = new Dictionary<string, string>();
    }
    public IEnumerator SendData(string url, WWWForm form, resultFunction resultFunction)
    {
        WWW www;

        if (this.hsHeader.Count > 0)
        {
            www = new WWW(url, form.data, hsHeader);
        }
        else
        {
            www = new WWW(url, form.data);
        }

        yield return www;
        SetSessionCookie(www);
        result = www.text;
        www.Dispose();
        resultFunction();
    }

    private void SetSessionCookie(WWW www)
    {
        Dictionary<string, string> headers = www.responseHeaders;
        foreach (KeyValuePair<string, string> kvPair in headers)
        {
            if (kvPair.Key.ToLower().Equals("set-cookie"))
            {
                string stHeader = "";
                string stJoint = "";
                string[] astCookie = kvPair.Value.Split(
                    new string[] { ";" }, System.StringSplitOptions.None);
                foreach (string stCookie in astCookie)
                {
                    if (!stCookie.Substring(0, 5).Equals("path ="))
                    {
                        stHeader += stJoint + stCookie;
                        stJoint = ";";
                    }
                }
                if (stHeader.Length > 0)
                {
                    this.hsHeader["Cookie"] = stHeader;
                }
                else
                {
                    this.hsHeader.Clear();
                }
            }
        }
    }
}