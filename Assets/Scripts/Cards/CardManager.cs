using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PositiveCardsManager;

public class CardManager : MonoBehaviour
{
    [SerializeField] GameObject cardImage;

    [SerializeField] Button effectButton;

    [SerializeField] List<Sprite> effectSprites;

    // Start is called before the first frame update
    void Start()
    {
        effectButton.image.sprite = default;
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

        cardImage.SetActive(true);
        cardImage.GetComponent<Image>().sprite = effectSprites[index];

        StartCoroutine(WaitCardAnim(index));
        
        effectButton.onClick.AddListener(delegate { ClickFunction(positiveEffects, index); });
    }

    void ChooseNegative(string name)
    {
        NegativeCardsManager negativeEffects = GetComponent<NegativeCardsManager>();
        int index = negativeEffects.ChooseRandomEffect(name);

        System.Delegate[] negatives = negativeEffects.negativeEffects.GetInvocationList();
        ((NegativeCardsManager.NegativeEffects)negatives[index]).Invoke();
    }

    void ClickFunction(PositiveCardsManager positiveEffects, int index)
    {
        System.Delegate[] positives = positiveEffects.positiveEffects.GetInvocationList();
        ((PositiveCardsManager.PositiveEffects)positives[index]).Invoke();

        effectButton.interactable = false;
        effectButton.image.sprite = default;

        effectButton.onClick.RemoveAllListeners();
    }

    IEnumerator WaitCardAnim(int index)
    {
        yield return new WaitUntil(() => !cardImage.activeSelf);

        effectButton.interactable = true;
        effectButton.image.sprite = effectSprites[index];
    }

}
