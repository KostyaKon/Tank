using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveTank : MonoBehaviour
{
    public float speed = 15000f, maxSpeed = 5;
    public float rotateSpeed = 15f;
    public Transform[] partTank;

    private Rigidbody rb;
    float horMove, verMove, speedTank;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        horMove = Input.GetAxis("Horizontal");
        verMove = Input.GetAxis("Vertical");

        rb.AddRelativeForce(new Vector3(0, 0, verMove) * speed);
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

        Quaternion deltaRotate = Quaternion.Euler(new Vector3(0, rotateSpeed * horMove, 0) * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotate);

        if (verMove != 0)
        {
            foreach (Transform part in partTank)
            {
                speedTank = rb.velocity.magnitude;
                part.localRotation = Quaternion.Euler(new Vector3(270f - 1.5f * verMove * speedTank, 0, 0));
                
            }
         }
    }
}
