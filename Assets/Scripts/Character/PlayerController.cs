using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float finishSpeed;

    Vector3 finishPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.gameState == GameState.Finish)
            transform.position = Vector3.MoveTowards(transform.position, finishPos, finishSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, finishPos) <= 0.01f) FinishManager.finishCheck = true;

        if (transform.position.y <= -30f) gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameController.gameState = GameState.GameOver;
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
        if (other.gameObject.CompareTag("Wall"))
        {
            GameController.gameState = GameState.GameOver;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            GameController.gameState = GameState.Finish;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            finishPos = other.gameObject.transform.position;
        }
    }

    void TouchCards(string tag, string name)
    {
        CardManager cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
        cardManager.ChooseEffect(tag, name);
    }

}
