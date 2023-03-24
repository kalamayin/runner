using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{
    [SerializeField] GameObject cardImage;

    [SerializeField] List<Button> effectButtons;

    [SerializeField] List<Sprite> effectSprites;

    public static int buttonIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        effectButtons[buttonIndex].image.sprite = default;
    }

    // Update is called once per frame
    void Update()
    {
        //cardImage.GetComponent<Image>().sprite = speed;
    }

    public void ChooseEffect(string effectName, string objectName)
    {
        if (effectName == "Positive") ChoosePositive(objectName);
        else if (effectName == "Negative") ChooseNegative(objectName);
    }

    void ChoosePositive(string name)
    {
        PositiveCardsManager positiveEffects = GetComponent<PositiveCardsManager>();
        int index = positiveEffects.ChooseRandomEffect(name);


        //if (buttonIndex == effectButtons.Count) ChangeButtons();
        //if (effectButtons.Count > 1) buttonIndex = EmptyButtonIndex();
        
        cardImage.SetActive(true);
        cardImage.GetComponent<Image>().sprite = effectSprites[index];

        StartCoroutine(WaitCardAnim(index));

        effectButtons[buttonIndex].onClick.AddListener(delegate { ClickFunction(positiveEffects, index); });
    }

    void ChooseNegative(string name)
    {
        NegativeCardsManager negativeEffects = GetComponent<NegativeCardsManager>();
        int index = negativeEffects.ChooseRandomEffect(name);

        System.Delegate[] negatives = negativeEffects.negativeEffects.GetInvocationList();
        ((NegativeCardsManager.NegativeEffects)negatives[index]).Invoke();

        StarManager.negativeCardCount++;
    }

    void ClickFunction(PositiveCardsManager positiveEffects, int index)
    {
        System.Delegate[] positives = positiveEffects.positiveEffects.GetInvocationList();
        ((PositiveCardsManager.PositiveEffects)positives[index]).Invoke();

        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        button.interactable = false;
        button.image.sprite = default;

        //ScrollUpButtons();

        StarManager.positiveCardCount++;
        
        button.onClick.RemoveAllListeners();
    }

    void SetButtonIndex()
    {
        if (buttonIndex < effectButtons.Count) buttonIndex++;
        //else buttonIndex = effectButtons.Count - 1;
    }

    int EmptyButtonIndex()
    {
        for(int i = 0; i < effectButtons.Count; i++)
        {
            if (!effectButtons[i].interactable)
            {
                return i;
            }
            else if(i == effectButtons.Count - 1 && effectButtons[i].interactable)
            {
                ChangeButtons();
                return i;
            }
        }

        return 0;
    }

    void ChangeButtons()
    {
        for (int i = 0; i < effectButtons.Count - 1; i++)
        {
            effectButtons[i].onClick.RemoveAllListeners();
            effectButtons[i].onClick = effectButtons[i + 1].onClick;
            effectButtons[i].image.sprite = effectButtons[i + 1].image.sprite;
            effectButtons[i].interactable = true;
            effectButtons[i + 1].onClick.RemoveAllListeners();
            effectButtons[i + 1].image.sprite = default;
            effectButtons[i + 1].interactable = false;
        }
        buttonIndex = effectButtons.Count - 1;
    }

    void ScrollUpButtons()
    {
        if(effectButtons.Count > 1)
        {
            if (!effectButtons[0].interactable && effectButtons[1].interactable) ChangeButtons();
        }
    }

    IEnumerator WaitCardAnim(int index)
    {
        //Debug.Log("Beklemede");
        yield return new WaitUntil(() => !cardImage.activeSelf);

        effectButtons[buttonIndex].interactable = true;
        effectButtons[buttonIndex].image.sprite = effectSprites[index];
        //Debug.Log("Çýktý");
        //SetButtonIndex();
    }

}