using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovementController : MonoBehaviour
{
    public enum EMovementMode
    {
        ENormalRide,
        EJump,
    }

    public EMovementMode movementMode;

    [HideInInspector] public float movementSpeed;
    [HideInInspector] public float textureXposition;
    float height;

    [Header("Jump")]
    public float jumpVelocityDamping;
    public float initialJumpVelocity;
    public float gravity;
    public AudioSource jumpSound;

    public void ResetState()
    {
        jumpHeight = 0;
        jumpVelocity = 0;
    }

    float jumpHeight;
    float jumpVelocity;

    CarWheelsController _carWheels;
    PlayerInputHolder _inputHolder;

    private void Awake()
    {
        _carWheels   = GetComponent<CarWheelsController>();
        _inputHolder = GetComponent<PlayerInputHolder>();

        ChangeCurrentMovementMode(movementMode);
    }

    void UpdateNormalRide()
    {
        _carWheels.UpdateWheelPosition(textureXposition);
        GroundTileManager.instance.GetWorldHeight_TextureCoords(textureXposition, out height);

        if (_inputHolder.jumpInput)
            ChangeCurrentMovementMode(EMovementMode.EJump);
    }
    void UpdateJump()
    {
        jumpHeight += (jumpVelocity - gravity) * Time.deltaTime;
        _carWheels.SetWheelDefaultPosition(textureXposition, jumpHeight);
    }
    void FixedUpdateJump()
    {
        jumpVelocity = Mathf.MoveTowards(jumpVelocity, 0, jumpVelocityDamping * Time.deltaTime);

        float currentHeight;
        GroundTileManager.instance.GetWorldHeight_TextureCoords(textureXposition, out currentHeight);
        if (jumpHeight < currentHeight)
        {
            ChangeCurrentMovementMode(EMovementMode.ENormalRide);
        }
    }

    Action movementModeUpdate;
    Action movementModeFixedUpdate;
    void ChangeCurrentMovementMode(EMovementMode mode)
    {
        movementMode = mode;
        switch (mode)
        {
            case EMovementMode.ENormalRide:
                movementModeUpdate = UpdateNormalRide;
                movementModeFixedUpdate = () => { };
                break;

            case EMovementMode.EJump:
                GroundTileManager.instance.GetWorldHeight_TextureCoords(textureXposition, out height);
                jumpHeight = height;
                movementModeUpdate = UpdateJump;
                movementModeFixedUpdate = FixedUpdateJump;
                jumpVelocity = initialJumpVelocity;
                jumpSound.PlayOneShot(jumpSound.clip);
                break;
        }
    }

    private void Update()
    {
        textureXposition += movementSpeed * Time.deltaTime * 400;

        movementModeUpdate();
    }
    private void FixedUpdate()
    {
        movementModeFixedUpdate();
    }
}
