using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed, horizontalSpeed;

    public float jumpForce, dashForce;

    [HideInInspector] public float highCoeff, frac;

    float coeff;

    public Rigidbody playerRB;

    public bool jumpCheck;


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
        if (GameController.gameState == GameState.Playing) playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed * coeff,
            playerRB.velocity.y, 1f * forwardSpeed * coeff);

        if (jumpCheck)
        {
            jumpCheck = false;
            playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed * coeff,
            jumpForce, 1f * forwardSpeed * coeff);
        }
    }
}
