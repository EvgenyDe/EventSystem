using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Poltergeist : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    [SerializeField] private GameObject plane;

    private Vector3 velocity;

    private void Reset()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rig.WakeUp();

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (velocity.magnitude > 0.1f)
        {
            rig.velocity = velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == plane)
        {
            return;
        }

        var targetMesh = collision.gameObject.GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = targetMesh;
    }

    private void OnCollisionStay(Collision collisionI)
    {
        if (collisionI.gameObject == plane)
        {
            plane.transform.Rotate(Time.deltaTime * 5f * Vector3.up);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == plane)
        {
            return;
        }
        
        Debug.Log($"Hasta la vista {other.gameObject}");
    }
}
