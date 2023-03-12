using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float translateSpeed;

    public static bool magnet, unmagnet;
    // Start is called before the first frame update
    void Start()
    {
        magnet = false;
        unmagnet = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (magnet) Magnet();
        if (unmagnet) UnMagnet();
    }

    void Magnet()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 targetPos = target.position;
        if (Vector3.Distance(targetPos, transform.position) <= 15f)
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
    }

    void UnMagnet()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 targetPos = target.position;
        Vector3 dir = transform.position - targetPos;
        if (Vector3.Distance(targetPos, transform.position) <= 20f)
            transform.Translate(dir.normalized * translateSpeed);
    }

}
