using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator Granny;

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
        Granny.Play("Dwarf Idle");
    }

    private void SimpleCharacterMovement_OnStartMoving(Vector3 obj)
    {
        Granny.Play("Female Walk");
        
    }
}

public enum PlayerMoveState
{
    Idle, Walking, Dancing
}