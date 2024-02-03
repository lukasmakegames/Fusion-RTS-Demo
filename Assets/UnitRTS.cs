using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class UnitRTS : NetworkBehaviour
{
    [SerializeField] private int owner = 1;

    public void MoveToPosition(Vector3 position, PlayerRef messageSource)
    {

        Debug.Log("local player:" + Runner.LocalPlayer.PlayerId);
        Debug.Log("owner:" + owner);
        Debug.Log("gameobject:" + gameObject);
        Debug.Log("position:" + position);
        if (messageSource.PlayerId == owner){
            GetComponent<MovePosition>().SetMovePosition(position);
        }
    }
}