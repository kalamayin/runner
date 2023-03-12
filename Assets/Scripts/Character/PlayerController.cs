using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Positive"))
        {
            TouchCards(other.gameObject.tag, other.gameObject.name);
        }
        else if (other.gameObject.CompareTag("Negative"))
        {
            TouchCards(other.gameObject.tag, other.gameObject.name);
        }
    }

    void TouchCards(string tag, string name)
    {
        CardManager cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
        cardManager.ChooseEffect(tag, name);
    }

}
