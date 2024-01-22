using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Reaction POC.
    /// </summary>
    public class TestReaction : MonoBehaviour, IReaction
    {
        [SerializeField]
        Transform t;

        public void React()
        {
            t.gameObject.SetActive(true);
        }

        public void ResetReaction()
        {
            t.gameObject.SetActive(false);
        }
    }

}
