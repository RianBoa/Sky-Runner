using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    public event Action JumpTap = () => { };

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            JumpTap.Invoke();
        }
    }

    private void OnDestroy()
    {
        JumpTap = () => { };
    }
}
