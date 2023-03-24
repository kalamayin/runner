using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameState gameState;

    [SerializeField] GameObject gameOverPanel;

    // Start is called before the first frame update
    void Awake()
    {
        gameState = GameState.Prepare;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.GameOver) gameOverPanel.SetActive(true);
    }
}
public enum GameState { Prepare, Playing, Pause, GameOver, Finish };