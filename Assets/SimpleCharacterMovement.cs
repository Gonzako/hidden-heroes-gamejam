using System;
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
    private Vector3 previousMove;

    public static event Action<Vector3> OnStartMoving = null;

    public static event Action OnStopMoving = null;

    private void Start()
    {
        charMove = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 ToMove = new Vector3(desiredSpeed.x, 0, desiredSpeed.y);
        
        if(previousMove != ToMove)
        {
            if(previousMove.magnitude == 0)
            {
                OnStartMoving?.Invoke(ToMove);
            }
            else if(ToMove.magnitude == 0)
            {
                OnStopMoving?.Invoke();
            }
        }

        charMove.Move(ToMove * MaxSpeed * Time.fixedDeltaTime);
        charMove.Move(Vector3.down * 9.8f);


        previousMove = ToMove;
    }

    public void SetSpeed(InputAction.CallbackContext ctx)
    {
        desiredSpeed = ctx.action.ReadValue<Vector2>();
    }
}
