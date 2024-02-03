using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MoveVelocity : NetworkBehaviour
{

    private float speed { get; set; }
    private Vector3 velocity { get; set; }

    private void Awake()
    {
        velocity = Vector3.zero;
        speed = 5.0f;
    }
    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public override void FixedUpdateNetwork()
    {
        // Move the character using the CharacterController
        GetComponent<CharacterController>().Move(velocity * speed * Runner.DeltaTime);
    }
}