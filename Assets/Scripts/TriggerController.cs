using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    private Rigidbody groundRigidBody;

    private void Start()
    {
        groundRigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        groundRigidBody.useGravity = true;
        Destroy(gameObject, 0.3f);
        GroundManager.groundsCreated--;
    }
}
