using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] float speed;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.Translate(Vector3.right * speed / 50);
        }
    }

}
