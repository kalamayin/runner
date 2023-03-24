using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float frac;

    public static float coeff;

    private void Start()
    {
        coeff = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.gameState == GameState.Playing) transform.Rotate(Vector3.forward * speed * coeff);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.Translate(Vector3.right * coeff * speed / frac);
        }
    }

}
