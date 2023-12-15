using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObserver : MonoBehaviour
{
    public BasicGrabbable grabbable;

    [SerializeField]
    public bool grabbed = false;

    [SerializeField]
    Material mat;
    Material baseMaterial;

    [SerializeField]
    GameObject handle;

    // Start is called before the first frame update
    void Start()
    {
        baseMaterial = handle.GetComponent<MeshRenderer>().material;
        grabbable = GetComponent<BasicGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        grabbed = grabbable.isGrabbed;

        if (grabbed)
        {
            handle.GetComponent<MeshRenderer>().material = mat;
        }
        else
        {
            handle.GetComponent<MeshRenderer>().material = baseMaterial;
        }

    }
}
