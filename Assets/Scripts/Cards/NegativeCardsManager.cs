using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeCardsManager : MonoBehaviour
{
    [Header("Time Of Negative Talents")]
    [SerializeField] float lowSpeedTime;
    [SerializeField] float unmagnetTime;
    [SerializeField] float obstacleSpeedTime;

    [SerializeField] float addTime;

    [SerializeField] float frac, obstacleCoeff;

    [SerializeField] GameObject cannon;

    public delegate void NegativeEffects();

    public NegativeEffects negativeEffects;

    private void Start()
    {
        negativeEffects += LowSpeed;
        negativeEffects += AddTime;
        negativeEffects += ObstacleSpeedUp;
        negativeEffects += CreateCannon;
        negativeEffects += Unmagnet;
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
        if (name == "RandomlyNegative") random = Random.Range(0, 5);
        else random = SetNumber(name);

        return random;
    }

    int SetNumber(string name)
    {
        int num = 0;
        if (name == "LowSpeed") num = 0;
        else if (name == "AddTime") num = 1;
        else if (name == "ObstacleSpeedUp") num = 2;
        else if (name == "CreateCannon") num = 3;
        else if (name == "Unmagnet") num = 4;
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
        CoinManager.unmagnet = true;
        yield return new WaitForSeconds(time);
        CoinManager.unmagnet = false;
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
