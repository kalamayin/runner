using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] int direction;

    [SerializeField] float rotateSpeed;

    public static float coeff;

    private void Start()
    {
        coeff = 1;
        if (direction == 0) SetDirectionRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState == GameState.Playing) 
            transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Sin(Time.time * rotateSpeed * coeff * direction) * 45f);
    }

    void SetDirectionRandomly()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                direction = 1;
                break;
            case 1:
                direction = -1;
                break;
            default:
                break;
        }
    }
}
