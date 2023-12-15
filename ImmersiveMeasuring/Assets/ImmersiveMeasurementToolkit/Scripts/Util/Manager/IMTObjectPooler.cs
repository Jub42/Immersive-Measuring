using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Pooler.
    /// </summary>
    public interface IMTObjectPooler
    {
        public bool AddObject(GameObject obj);
    }
}

