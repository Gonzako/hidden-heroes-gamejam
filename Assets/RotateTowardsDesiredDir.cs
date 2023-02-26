using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateTowardsDesiredDir : MonoBehaviour
{
    public float rotateSpeed = 20f;

    //Representation of player input
    private Vector2 desiredDir;
    private bool turnEnable = false;

    public void RecieveLastInput(InputAction.CallbackContext ctx)
    {
        var varDesiredDir = ctx.action.ReadValue<Vector2>();
        if(varDesiredDir.magnitude < 0.2f)
        {
            turnEnable = false;
            return;
        }
        desiredDir = ctx.action.ReadValue<Vector2>();
        turnEnable = true;
    }

    private void LateUpdate()
    {
        var toMove = new Vector3(desiredDir.x, 0, desiredDir.y);
        if (transform.forward != toMove  && turnEnable)
        {

            var targetVect = Vector3.RotateTowards(transform.forward, toMove, rotateSpeed * Mathf.Deg2Rad, 2000f);
            if(targetVect.magnitude < 0.2f) { return; }
            transform.forward = targetVect;
        }

    }
}
