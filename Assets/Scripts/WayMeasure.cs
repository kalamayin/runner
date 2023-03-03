using UnityEngine;
using UnityEngine.UI;

public class WayMeasure : MonoBehaviour
{
    Slider wayMeasure;

    [SerializeField] Transform playerTransform, finishTransform;

    // Start is called before the first frame update
    void Start()
    {
        wayMeasure = GetComponent<Slider>();
        wayMeasure.minValue = playerTransform.position.z;
        wayMeasure.maxValue = finishTransform.position.z;
        wayMeasure.value = playerTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        wayMeasure.value = playerTransform.position.z;
    }
}
