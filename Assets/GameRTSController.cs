using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class GameRTSController : NetworkBehaviour
{

    public LayerMask groundLayer; // Assign the ground layer in the Inspector

    private void Update()
    {

        if (Object != null)
            if (Input.GetMouseButtonDown(1))
            {
                // Cast a ray from the mouse position into the scene
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if the ray hits the ground layer
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
                {
                    // Get the point where the ray hits the ground
                    Vector3 mousePositionWorld = hit.point;

                    foreach (GameObject unit in SC_SelectionManager.GetSelectedGameObjects())
                    {
                        RPC_MoveUnit(unit.GetComponent<UnitRTS>(), mousePositionWorld);

                    }
                }
            }
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority, HostMode = RpcHostMode.SourceIsHostPlayer)]
    public void RPC_MoveUnit(UnitRTS unit, Vector3 position, RpcInfo info = default)
    {
        RPC_RelayMoveUnit(unit, position, info.Source);
    }
    [Rpc(RpcSources.StateAuthority, RpcTargets.All, HostMode = RpcHostMode.SourceIsServer)]
    public void RPC_RelayMoveUnit(UnitRTS unit, Vector3 position, PlayerRef messageSource)
    {
            unit.MoveToPosition(position, messageSource);
    }

}
