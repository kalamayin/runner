using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Range (-1, 1)]
    [SerializeField] int direction;

    [SerializeField] float speed;

    public static float coeff;

    private void Start()
    {
        coeff = 1f;
        StartCoroutine(Delay());
        if (direction == 0) SetDirectionRandomly();
    }

    void FixedUpdate()
    {
        if(GameController.gameState == GameState.Playing) transform.Rotate(Vector3.up * speed * direction * coeff);
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

    IEnumerator Delay()
    {
        float temp = speed;
        speed = 0f;
        float time = Random.Range(0, 1f);
        yield return new WaitForSeconds(time);
        speed = temp;
    }
}
