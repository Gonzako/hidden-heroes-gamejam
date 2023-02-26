using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float MaxSpeed = 10f;

    private CharacterController charMove;

    //Representation of player input
    private Vector2 desiredSpeed;

    private void Start()
    {
        charMove = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 ToMove = new Vector3(desiredSpeed.x, 0, desiredSpeed.y);
        charMove.Move(ToMove * MaxSpeed * Time.fixedDeltaTime);

    }

    public void SetSpeed(InputAction.CallbackContext ctx)
    {
        desiredSpeed = ctx.action.ReadValue<Vector2>();
    }
}
