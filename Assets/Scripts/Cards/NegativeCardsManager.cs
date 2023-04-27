using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PositiveCardsManager;

public class NegativeCardsManager : MonoBehaviour
{
    [Header("Time Of Negative Talents")]
    [SerializeField] float lowSpeedTime;
    [SerializeField] float unmagnetTime;
    [SerializeField] float obstacleSpeedTime;

    [SerializeField] float addTime;

    [SerializeField] float frac, obstacleCoeff;

    [SerializeField] GameObject cannon;

    string openedNegativeEffect = "OpenedNegativeEffect";

    public delegate void NegativeEffects();

    public NegativeEffects negativeEffects;

    private void Awake()
    {
        //PlayerPrefs.DeleteKey(openedNegativeEffect);
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey(openedNegativeEffect)) PlayerPrefs.SetInt(openedNegativeEffect, 0);
    }

    private void Start()
    {
        //PlayerPrefs.DeleteKey(openedNegativeEffect);
        //PlayerPrefs.DeleteKey("ObstacleSpeedUp");
        negativeEffects += LowSpeed;
        negativeEffects += AddTime;
        negativeEffects += ObstacleSpeedUp;
        negativeEffects += CreateCannon;
        negativeEffects += Unmagnet;
        SetNegativeCardNumber();
        Debug.Log("Negative: " + PlayerPrefs.GetInt(openedNegativeEffect));
        
    }

    void SetNegativeCardNumber()
    {
        GameObject[] positiveCards = GameObject.FindGameObjectsWithTag("Negative");
        int num = PlayerPrefs.GetInt(openedNegativeEffect);

        foreach (GameObject obj in positiveCards)
        {
            if (obj.name != "RandomlyNegative" && !PlayerPrefs.HasKey(obj.name))
            {
                PlayerPrefs.SetString(obj.name, "opened");
                PlayerPrefs.SetInt(openedNegativeEffect, num + 1);
            }
        }
    }

    void LowSpeed()
    {
        StartCoroutine(LowSpeed(lowSpeedTime));
    }

    void AddTime()
    {
        //TimeManager.count = GameObject.Find("Timer").GetComponent<Timing>();
        TimeManager.count += addTime;
    }

    void CreateCannon()
    {
        cannon.SetActive(true);
    }

    void ObstacleSpeedUp()
    {
        StartCoroutine(ObstacleSpeedUp(obstacleSpeedTime));
    }

    void Unmagnet()
    {
        StartCoroutine(Unmagnet(unmagnetTime));
    }

    public int ChooseRandomEffect(string name)
    {
        int random;
        int length = PlayerPrefs.GetInt(openedNegativeEffect);
        if (name == "RandomlyNegative") random = Random.Range(0, length);
        else random = SetNumber(name);

        return random;
    }

    int SetNumber(string name)
    {
        int num = 0;
        switch (name)
        {
            case "LowSpeed":
                num = 0;
                break;
            case "AddTime":
                num = 1;
                break;
            case "ObstacleSpeedUp":
                num = 2;
                break;
            case "CreateCannon":
                num = 3;
                break;
            case "Unmagnet":
                num = 4;
                break;
        }
        return num;
    }

    IEnumerator LowSpeed(float time)
    {
        PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        movement.frac = frac;
        yield return new WaitForSeconds(time);
        movement.frac = 1f;
    }

    IEnumerator Unmagnet(float time)
    {
        CoinMovement.unmagnet = true;
        yield return new WaitForSeconds(time);
        CoinMovement.unmagnet = false;
    }

    IEnumerator ObstacleSpeedUp(float time)
    {
        SetObstaclesCoeff(obstacleCoeff);
        yield return new WaitForSeconds(time);
        SetObstaclesCoeff(1);
    }

    void SetObstaclesCoeff(float coeff)
    {
        HorizontalMovement.coeff = coeff;
        HalfDonut.coeff = coeff;
        RotateBall.coeff = coeff;
        RotatingPlatform.coeff = coeff;
        Rotator.coeff = coeff;
    }

}
