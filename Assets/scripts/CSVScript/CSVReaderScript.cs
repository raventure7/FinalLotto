using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CSVReaderScript : MonoBehaviour
{
    static CSVReaderScript csvReaderScript;

    public List<Dictionary<string, object>> dateData;

    public static CSVReaderScript Instance
    {
        get { return csvReaderScript; }
    }

    private void Awake()
    {
        csvReaderScript = this;
        DateRead();
    }

    // 회차별 날짜 데이터를 가져온다.
    void DateRead()
    {
        dateData = CSVReader.Read("csv/date");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
