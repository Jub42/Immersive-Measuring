using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IMTTriggerCluster : MonoBehaviour
{
    [SerializeField]
    List<IMTTrigger> triggers = new List<IMTTrigger>();

    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

    void Update()
    {
        if (triggers.Count < 1) return;

        for(int i = 0; i < triggers.Count; i++)
        {
            if (triggers[i].IsEntered)
            {
                Enter();
            }
            if (triggers[i].IsStayed)
            {
                Stay();
            }
            if (triggers[i].IsExited)
            {
                Exit();
            }

            continue;
        }
    }

    void Enter()
    {
        onTriggerEnter.Invoke();
    }
    void Stay()
    {
        onTriggerStay.Invoke();
    }
    void Exit()
    {
        onTriggerExit.Invoke();
    }
}
