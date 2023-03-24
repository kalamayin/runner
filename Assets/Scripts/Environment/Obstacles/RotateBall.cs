using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    public static float coeff;

    private void Start()
    {
        coeff = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState == GameState.Playing) 
            transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Sin(Time.time * rotateSpeed * coeff) * 45f);
    }
}
