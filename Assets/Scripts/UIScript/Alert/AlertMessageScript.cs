using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertMessageScript : MonoBehaviour
{
    static AlertMessageScript alertMessage;
    public AlertCopyScript alertCopy;
    public AlertAnalysisScript alertAnalysis;


    public static AlertMessageScript Instance
    {
        get { return alertMessage; }
    }

    private void Awake()
    {
        alertMessage = this;        
    }

    public void ViewCopy(int index)
    {
        alertCopy.copyIndex = index;
        alertCopy.SetActive(true);
    }

    public void ViewAnalysis(int index)
    {
        alertAnalysis.index = index;
        alertAnalysis.SetActive(true);
    }
}
