using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSpeedupController : MonoBehaviour
{
    [Range(0, 1), SerializeField]
    float _offsetPercent;
    public float offsetPercent
    {
        get => _offsetPercent;
        set
        {
            _offsetPercent = value;
            _cameraController.xOffset = Mathf.Lerp(offsetMin, offsetMax, _offsetPercent);
            _carMovementController.movementSpeed = Mathf.Lerp(movementSpeedMin, movementSpeedMax, _offsetPercent);
        }

    }
    public float offsetChangeSpeed;


    [Header("Min")]
    public float offsetMin;
    public float movementSpeedMin;

    [Header("Max")]
    public float offsetMax;
    public float movementSpeedMax;

    CameraController _cameraController;
    CarMovementController _carMovementController;
    PlayerInputHolder _inputHolder;

    private void Start()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
        _carMovementController = GetComponent<CarMovementController>();
        _inputHolder = GetComponent<PlayerInputHolder>();

        // just to call set function;
        offsetPercent = _offsetPercent;
    }

    private void Update()
    {
        if (_inputHolder.forwardInput)
            offsetPercent = Mathf.Clamp01(offsetPercent + offsetChangeSpeed);
        else if (_inputHolder.backwardInput)
            offsetPercent = Mathf.Clamp01(offsetPercent - offsetChangeSpeed);
    }


}
