using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator Granny;

    private bool moving = false;

    private void OnDisable()
    {
        SimpleCharacterMovement.OnStartMoving -= SimpleCharacterMovement_OnStartMoving;
        SimpleCharacterMovement.OnStopMoving -= SimpleCharacterMovement_OnStopMoving;
    }

    private void OnEnable()
    {
        SimpleCharacterMovement.OnStartMoving += SimpleCharacterMovement_OnStartMoving;
        SimpleCharacterMovement.OnStopMoving += SimpleCharacterMovement_OnStopMoving;
    }

    private void SimpleCharacterMovement_OnStopMoving()
    {
        moving = false;
        if (FoodPickupAndServe.IsHolding)
        {

            Granny.Play("Pole Walking");
            Granny.speed = 0.1f;
        }
        else
        {
            Granny.speed = 1f;
            Granny.Play("Dwarf Idle");
        }
    }

    private void SimpleCharacterMovement_OnStartMoving(Vector3 obj)
    {
        moving = true;
        Granny.speed = 1f;
        if (FoodPickupAndServe.IsHolding)
        {

            Granny.Play("Pole Walking");
        }
        else
        {

            Granny.Play("Female Walk");
        }
        
    }

    public void SetHoldAnim(bool isHolding)
    {
        if (FoodPickupAndServe.IsHolding)
        {
            Granny.speed = moving ? 1f : 0.1f;
            Granny.Play("Pole Walking");
        }
        else
        {

            Granny.Play("Female Walk");
        }
        
    }
}

public enum PlayerMoveState
{
    Idle, Walking, Dancing
}