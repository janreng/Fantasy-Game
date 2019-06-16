﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToPoint(Vector3 point)
    {          
        agent.SetDestination(point);
    }

    public float currentSpeed()
    {
        return agent.velocity.magnitude / agent.speed;
    }
}
