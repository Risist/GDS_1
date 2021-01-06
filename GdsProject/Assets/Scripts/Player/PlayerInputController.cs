using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public KeyCode forwardInputKeyCode;
    public KeyCode backwardInputKeyCode;
    public KeyCode jumpInputKeyCode;
    public KeyCode shootInputKeyCode;

    PlayerInputHolder _holder;

    void Start()
    {
        _holder = GetComponentInChildren<PlayerInputHolder>();    
    }

    private void Update()
    {
        _holder.forwardInput = Input.GetKey(forwardInputKeyCode);
        _holder.backwardInput = Input.GetKey(backwardInputKeyCode);

        _holder.jumpInput  = Input.GetKey(jumpInputKeyCode);
        _holder.shootInput = Input.GetKey(shootInputKeyCode);
    }
}
