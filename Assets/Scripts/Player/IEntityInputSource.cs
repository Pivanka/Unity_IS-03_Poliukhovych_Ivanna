using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }
        float VerticalDirection { get; }

        bool Jump { get; }

        void ResetOneTimeActions();
    }
}
