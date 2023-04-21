using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;

    [SerializeField] List<Image> starImages;

    public static bool finishCheck;

    // Start is called before the first frame update
    void Start()
    {
        finishCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState == GameState.Finish && finishCheck)
        {
            finishPanel.SetActive(true);
            SetStarImages();
            SaveStarInfo();
        }
    }

    void SetStarImages()
    {
        int index = 0;
        foreach(bool check in StarManager.goalCheck)
        {
            if (check) starImages[index].enabled = true;
            index++;
        }
    }

    void SaveStarInfo()
    {
        int count = 0;
        foreach (bool check in StarManager.goalCheck)
        {
            if (check) count++;
        }
        int level = SceneManager.GetActiveScene().buildIndex;
        if (!PlayerPrefs.HasKey("Level" + level.ToString())) PlayerPrefs.SetInt("Level" + level.ToString(), count);
        else if(PlayerPrefs.HasKey("Level" + level.ToString()) && count > PlayerPrefs.GetInt("Level" + level.ToString()))
            PlayerPrefs.SetInt("Level" + level.ToString(), count);
    }

}
