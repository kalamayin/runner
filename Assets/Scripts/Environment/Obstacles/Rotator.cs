using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float speed;

    public static float coeff;

    private void Start()
    {
        coeff = 1f;
        StartCoroutine(Delay());
    }

    void FixedUpdate()
    {
        if(GameController.gameState == GameState.Playing) transform.Rotate(Vector3.up * speed * coeff);
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
