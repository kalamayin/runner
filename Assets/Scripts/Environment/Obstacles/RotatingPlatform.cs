using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] int direction;

    [SerializeField] float speed;
    [SerializeField] float frac;

    public static float coeff;

    private void Start()
    {
        coeff = 1;
        if (direction == 0) SetDirectionRandomly();
        Debug.Log(this.name + " " + direction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.gameState == GameState.Playing) transform.Rotate(Vector3.forward * direction * speed * coeff);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.Translate(Vector3.right * direction * coeff * speed / frac);
        }
    }

    void SetDirectionRandomly()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                direction = 1;
                break;
            case 1:
                direction = -1;
                break;
            default:
                break;
        }
    }

}
