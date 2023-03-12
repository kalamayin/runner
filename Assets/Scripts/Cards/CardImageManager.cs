using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardImageManager : MonoBehaviour
{
    [SerializeField] RectTransform positiveButton;
    [SerializeField] float speed, scaleSpeed, rotateSpeed;
    [SerializeField] Vector2 imageScale;
    RectTransform imageTransform;

    [SerializeField] float time;

    bool isStart;

    private void OnEnable()
    {
        imageTransform = GetComponent<RectTransform>();
        imageTransform.anchoredPosition = Vector2.zero;
        imageTransform.sizeDelta = imageScale;
        StartCoroutine(WaitForAnim());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStart)
        {
            Vector2 obj, target;
            obj = RectTransformUtility.WorldToScreenPoint(Camera.main, gameObject.transform.position);
            target = RectTransformUtility.WorldToScreenPoint(Camera.main, positiveButton.transform.position);
            
            gameObject.transform.position = Vector2.MoveTowards(obj, target, speed);
            imageTransform.sizeDelta = Vector2.MoveTowards(imageTransform.sizeDelta,
                positiveButton.sizeDelta, scaleSpeed);
            imageTransform.Rotate(new Vector3(0f, rotateSpeed, 0f));
            if (Vector2.Distance(gameObject.transform.position, positiveButton.transform.position) <= 5) gameObject.SetActive(false);
        }
    }

    IEnumerator WaitForAnim()
    {
        isStart = false;
        yield return new WaitForSeconds(time);
        isStart = true;
    }

}
