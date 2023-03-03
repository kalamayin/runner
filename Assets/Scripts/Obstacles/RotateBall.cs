using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(0f, 0f, 45f));
        //transform.localEulerAngles = new Vector3(0f, 0f, Mathf.PingPong(Time.time * rotateSpeed, 45f));
        transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Sin(Time.time * rotateSpeed) * 45f);
    }
}
