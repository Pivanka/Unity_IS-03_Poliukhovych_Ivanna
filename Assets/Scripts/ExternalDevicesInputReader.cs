using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ExternalDevicesInputReader : IEntityInputSource
{
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public float VerticalDirection => Input.GetAxisRaw("Vertical");
    public bool Jump { get; private set; }

    public void OnUpdate()
    {
        if (Input.GetButtonDown("Jump"))
            Jump = true;
    }

    public void ResetOneTimeActions()
    {
        Jump = false;
    }
}
