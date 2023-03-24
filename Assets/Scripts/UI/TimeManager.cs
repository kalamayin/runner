using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;

    public static float count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.gameState == GameState.Playing) count += Time.deltaTime;
        timer.text = count.ToString("0");
    }
}
