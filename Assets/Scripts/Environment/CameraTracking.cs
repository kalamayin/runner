using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] [Range(0.1f, 1f)] float smoothSpeed;
    [SerializeField] Vector3 offset;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        transform.LookAt(target);
    }

    private void Update()
    {
        float yClamp = Mathf.Clamp(transform.position.y, 2f, 20f);
        float xClamp = Mathf.Clamp(transform.position.x, -4f, 4f);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
    }
}
