using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Not in use!
    /// Interface for classes that should react to a hover event.
    /// In this Version the IMTTriggerCluster handles this function.
    /// </summary>
    public interface IHoverable
    {
        public void OnHoverEnter();
        public void OnHoverStay();
        public void OnHoverExit();
    }
}

