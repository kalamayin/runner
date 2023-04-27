using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static int coinCount;

    //int maxCoinNumber;

    TextMeshProUGUI coinText, totalCoinText;

    bool finish;

    public static bool coinTextCheck, totalCoinTextCheck;

    string maxCoinNumber = "MaxCoinNumber";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(maxCoinNumber)) PlayerPrefs.SetInt(maxCoinNumber, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        coinTextCheck = false;
        totalCoinTextCheck = false;
        finish = false;
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CatchCoinTexts();
        SetMaxNumber();
        SetCoinTexts();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
        }
    }

    void CatchCoinTexts()
    {
        if (coinTextCheck)
        {
            coinTextCheck = false;
            coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();
        }
            
        if(totalCoinTextCheck)
        {
            totalCoinTextCheck = false;
            totalCoinText = GameObject.FindGameObjectWithTag("TotalCoinText").GetComponent<TextMeshProUGUI>();
        }
    }

    void SetCoinTexts()
    {
        if(coinText != null && GameController.gameState == GameState.Playing) coinText.text = "Coin: " + coinCount.ToString();
        if(totalCoinText != null && GameController.gameState == GameState.Finish) 
            totalCoinText.text = "Total Coin: " + PlayerPrefs.GetInt(maxCoinNumber);
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
