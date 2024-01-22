using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Interface for a reaction.
    /// </summary>
    public interface IReaction
    {
        void React();
        void ResetReaction();
    }
}

