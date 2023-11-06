using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTest : MonoBehaviour
{
    [SerializeField]
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hover()
    {
        t.gameObject.SetActive(true);
    }
    public void DontHover()
    {
        t.gameObject.SetActive(false);
    }
}
