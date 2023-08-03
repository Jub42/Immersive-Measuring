using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardDisplay : MonoBehaviour
{
    [SerializeField]
    Transform display;

    void Awake()
    {
        display.gameObject.SetActive(false);
    }

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            transform.LookAt(Camera.main.transform.position);
        } 
    }

    public void OnHoverEnter()
    {
        display.gameObject.SetActive(true); 
    }
    public void OnHoverExit()
    {
        display.gameObject.SetActive(false);
    }
}
