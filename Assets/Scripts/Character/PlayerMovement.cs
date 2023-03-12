using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public const float FORWARD = 2f;
    //public const float HORIZONTAL = 3f;
    [SerializeField] float forwardSpeed, horizontalSpeed;

    public float jumpForce, dashForce;

    [HideInInspector] public float highCoeff, frac;

    float coeff;

    bool ground;
    

    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        highCoeff = 1;
        frac = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coeff = highCoeff / frac;
        if (!PlayerController.gameOver ) playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed * coeff,
            playerRB.velocity.y, 1f * forwardSpeed * coeff);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) ground = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) ground = false;
    }
}
