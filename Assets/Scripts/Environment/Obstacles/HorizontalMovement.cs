using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] int direction;

    [SerializeField]
    Vector3[] points;

    Vector3 patrol;

    [SerializeField] float patrolSpeed;

    int index;


    public static float coeff;

    private void Start()
    {
        coeff = 1;
        if(direction == 0) SetDirectionRandomly();
        if (direction == -1) index = 1;
        else if (direction == 1) index = 0;
    }

    void FixedUpdate()
    {
        if (GameController.gameState == GameState.Playing) Patrol();
    }

    void Patrol()
    {
        patrol = new Vector3(points[index].x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, patrol, patrolSpeed * coeff);
        if(Vector3.Distance(transform.position, patrol) <= 0.1f)
        {
            if (index == 0)
            {
                index++;
            }
            else if (index == 1)
            {
                index--;
            }
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
