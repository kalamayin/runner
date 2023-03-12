using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    [SerializeField] int level;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("MaxLevel");
        if (!PlayerPrefs.HasKey("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", 1);
        //PlayerPrefs.SetInt("MaxLevel", 3);
        Debug.Log("Level: " + PlayerPrefs.GetInt("MaxLevel"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
    }

    // Update is called once per frame
    void Update()
    {
        if(level > PlayerPrefs.GetInt("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", level);
    }
}
