using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardImageManager : MonoBehaviour
{
    [SerializeField] List<RectTransform> positiveButtons;
    [SerializeField] float speed, scaleSpeed, rotateSpeed;
    [SerializeField] Vector2 imageScale;
    RectTransform imageTransform;

    [SerializeField] float time;

    Vector2 target;

    bool isStart;

    int index = 0;

    private void OnEnable()
    {
        imageTransform = GetComponent<RectTransform>();
        imageTransform.anchoredPosition = Vector2.zero;
        imageTransform.rotation = Quaternion.identity;
        imageTransform.sizeDelta = imageScale;
        StartCoroutine(WaitForAnim());
        //target = RectTransformUtility.WorldToScreenPoint(Camera.main, positiveButtons[index].transform.position);
        target = positiveButtons[index].transform.position;
        Debug.Log("Normal pos: " + positiveButtons[index].transform.position + " transform pos: " + target);
        //SetIndex();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStart)
        {
            Vector2 obj;
            obj = RectTransformUtility.WorldToScreenPoint(Camera.main, gameObject.transform.position);
            
            gameObject.transform.position = Vector2.MoveTowards(transform.position, target, speed);
            imageTransform.sizeDelta = Vector2.MoveTowards(imageTransform.sizeDelta,
                positiveButtons[CardManager.buttonIndex].sizeDelta, scaleSpeed);
            imageTransform.Rotate(new Vector3(0f, rotateSpeed, 0f));
            if (Vector2.Distance(gameObject.transform.position, target) <= 5)
                gameObject.SetActive(false);
        }
    }

    void SetIndex()
    {
        if (index < positiveButtons.Count - 1) index++;
        else index = positiveButtons.Count - 1;
    }

    IEnumerator WaitForAnim()
    {
        isStart = false;
        yield return new WaitForSeconds(time);
        isStart = true;
    }

}
