using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterTrigger : MonoBehaviour
{
    [SerializeField]
    List<IMTTrigger> trigger;
    [SerializeField]
    Material hoverMaterial;

    List<Material> materials;

    bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trigger.Count; i++)
        {
            materials.Add(trigger[i].gameObject.GetComponent<MeshRenderer>().material);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < trigger.Count; i++)
        {
            if (trigger[i].isTriggered)
            {
                this.isTriggered = true;
                break;
            }
        }

        UpdateMat();
    }

    void UpdateMat()
    {
        if(isTriggered)
        {
            for (int i = 0; i < trigger.Count; i++)
            {
                trigger[i].gameObject.GetComponent<MeshRenderer>().material = hoverMaterial;
            }
        }
        else
        {
            for (int i = 0; i < trigger.Count; i++)
            {
                trigger[i].gameObject.GetComponent<MeshRenderer>().material = materials[i];
            }
        }
    }
}
