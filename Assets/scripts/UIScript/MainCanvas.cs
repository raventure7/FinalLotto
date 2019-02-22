using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    static MainCanvas mainCanvas;
    public NumberManagerScript numberManager;

    public static MainCanvas Instance
    {
        get { return mainCanvas; }
    }
    private void Awake()
    {
        mainCanvas = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
