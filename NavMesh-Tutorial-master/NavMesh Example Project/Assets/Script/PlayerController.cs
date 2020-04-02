using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class PlayerController : MonoBehaviour
{
    public Camera camera;

    public NavMeshAgent agent;

    public ThirdPersonCharacter charcter;

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if( charcter != null)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                charcter.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                charcter.Move(Vector3.zero, false, false);
            }
        }
    }

    void OnDrawGizmosSelected() {
        var path = agent.path;
        if( path.corners.Length < 1) return;
        for( int i = 1; i < path.corners.Length; i++)
        {
            Gizmos.DrawLine(path.corners[i-1], path.corners[i]);
        }
    }
}
