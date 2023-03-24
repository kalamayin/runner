using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    Vector3 point;

    [SerializeField] float speed;
    private void OnEnable()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        point = target.position;
        transform.position = point + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, point, speed);
        if (Vector3.Distance(transform.position, point) <= 0.05f) gameObject.SetActive(false);
    }
}
