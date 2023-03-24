using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameController.gameState = GameState.GameOver;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            GameController.gameState = GameState.Finish;
            Debug.Log("Finish line: " + GameController.gameState);
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
