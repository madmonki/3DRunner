using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    
    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    public Vector3 OpponentStartPos;
    public GameObject speedBoosterIcon;

    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = OpponentStartPos;
        }
    }
}
