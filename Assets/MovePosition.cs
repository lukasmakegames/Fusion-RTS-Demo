using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MovePosition : NetworkBehaviour
{
    private Vector3 movePosition;

    private void Awake()
    {
        movePosition = transform.position;
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        Debug.Log("unit moved!");
    }

    public override void FixedUpdateNetwork()
    {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        if (Vector3.Distance(movePosition, transform.position) < 1f) moveDir = Vector3.zero;
        GetComponent<MoveVelocity>().SetVelocity(moveDir);
    }
}