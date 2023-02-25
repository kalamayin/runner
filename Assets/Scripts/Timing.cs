using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;

    float count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        timer.text = count.ToString("0");
    }
}
