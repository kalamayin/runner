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

    Touch touch;

    public bool jumpCheck;

    Joystick joystick;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        highCoeff = 1;
        frac = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coeff = highCoeff / frac;
        if (GameController.gameState == GameState.Playing) playerRB.velocity = new Vector3(HorizontalInput() * horizontalSpeed * coeff,
            playerRB.velocity.y, 1f * forwardSpeed * coeff);
        else playerRB.velocity = Vector3.zero;

        if (jumpCheck)
        {
            jumpCheck = false;
            playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed * coeff,
            jumpForce, 1f * forwardSpeed * coeff);
        }
    }

    float HorizontalInput()
    {
        float horizontalInput = 0f;

        if (Input.GetAxis("Horizontal") != 0f) horizontalInput = Input.GetAxis("Horizontal");
        else if (joystick.Horizontal != 0f) horizontalInput = joystick.Horizontal;

        //if(Input.touchCount > 0)
        //{
        //    Debug.Log(Input.touchCount);
        //    touch = Input.GetTouch(0);
        //    //Debug.Log("Screen: " + Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane)));
        //    float firstInput = 0f, currentInput = 0f;

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Vector2 inputVector = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
        //        firstInput = inputVector.x;
        //        Debug.Log("Input Vector: " + inputVector + " first Input: " + firstInput);
        //    } //firstInput = 0f; //Camera.main.ScreenToWorldPoint(touch.position).x;
        //    else if (touch.phase == TouchPhase.Moved)
        //    {
        //        Vector2 inputVector = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
        //        currentInput = inputVector.x;
        //        Debug.Log("Input Vector: " + inputVector + " current Input: " + currentInput);
        //    } //currentInput = 1f; //Camera.main.ScreenToWorldPoint(touch.position).x;
        //    else if (touch.phase == TouchPhase.Ended)
        //    {
        //        firstInput = 0f;
        //        currentInput = 0f;
        //    }
            
        //    if(touch.phase != TouchPhase.Ended)
        //    {
        //        horizontalInput = (currentInput - firstInput);
        //        Debug.Log("Ham Horizontal" + horizontalInput);
        //    }
        //    horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        //    Debug.Log("Clamp Horizontal" + horizontalInput);
        //}

        return horizontalInput;
    }
}
