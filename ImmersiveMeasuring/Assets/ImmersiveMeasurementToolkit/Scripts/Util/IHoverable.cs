using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public interface IHoverable
    {
        public void OnHoverEnter();
        public void OnHoverStay();
        public void OnHoverExit();
    }
}

