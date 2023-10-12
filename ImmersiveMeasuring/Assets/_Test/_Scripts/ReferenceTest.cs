using MeasurementUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReferenceTest : MonoBehaviour
{
    List<int> list = new List<int>()
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10
    };

    [SerializeField]
    GameObject prefab;

    IMTList<int> mList;

    // Start is called before the first frame update
    void Start()
    {
        mList = new IMTList<int>(list);
        Debug.Log(mList.GetTList());

        Measurement m;

        GetComponent<IMTDataCube>().GetMeasurement(out m);

        Debug.Log(m.ToJson());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

