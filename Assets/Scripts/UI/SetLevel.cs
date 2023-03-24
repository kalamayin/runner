using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    //[SerializeField] List<Button> levelsButton;
    //[SerializeField] List<Image> levelsImage;

    [SerializeField] List<GameObject> levelButtons;

    [SerializeField] Sprite starImage;

    // Start is called before the first frame update
    void Awake()
    {
        //for (int i = 0; i < gameObject.transform.childCount; i++)
        //{
        //    levelButtons.Add(gameObject.transform.GetChild(i).gameObject);
        //}

        if (PlayerPrefs.GetInt("MaxLevel") <= 0) PlayerPrefs.SetInt("MaxLevel", 1);
        if (PlayerPrefs.GetInt("MaxLevel") > levelButtons.Count) PlayerPrefs.SetInt("MaxLevel", levelButtons.Count);
        

        SetUnlockedLevel();
        SetStarsLevels();
    }

    void SetUnlockedLevel()
    {
        for(int i = 0; i < PlayerPrefs.GetInt("MaxLevel"); i++)
        {
            Button btn = levelButtons[i].GetComponent<Button>();
            Image img = levelButtons[i].GetComponent<Image>();

            btn.enabled = true;
            img.color = new Color(255, 255, 255, 1);
        }
    }

    void SetStarsLevels()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("MaxLevel"); i++)
        {
            Image[] imgs = levelButtons[i].GetComponentsInChildren<Image>();

            for(int j = 0; j < PlayerPrefs.GetInt("Level" + (i + 1).ToString()); j++)
            {
                imgs[j + 1].sprite = starImage;
            }
            
        }
    }

    public void OpenLevel()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(levelName);
    }
}
