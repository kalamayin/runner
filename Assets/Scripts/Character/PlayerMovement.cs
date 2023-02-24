using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed, horizontalSpeed;
    

    Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed, playerRB.velocity.y, 1f * forwardSpeed);
    }
}
