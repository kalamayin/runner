using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    int coinCount;

    //int maxCoinNumber;

    bool finish;

    string maxCoinNumber = "MaxCoinNumber";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(maxCoinNumber)) PlayerPrefs.SetInt(maxCoinNumber, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetMaxNumber();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
        }
    }

    void SetMaxNumber()
    {
        if (GameController.gameState == GameState.Finish && !finish)
        {
            finish = true;
            int maxNumber = PlayerPrefs.GetInt(maxCoinNumber);
            PlayerPrefs.SetInt(maxCoinNumber, maxNumber + coinCount);
            coinCount = 0;
        }
    }

}
