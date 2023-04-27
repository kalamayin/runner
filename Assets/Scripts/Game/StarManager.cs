using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class StarManager : MonoBehaviour
{
    enum GoalOfStars
    {
        TimeTracking,
        UsePositiveCard,
        UseNegativeCard,
        DontUseAnyCard,
        DontUsePositiveCard,
        DontUseNegativeCard,
        CollectCoin
    };

    enum TextIndex { first, second, third};

    TextIndex textIndex;

    [Header("Options of Goals")]
    [SerializeField] GoalOfStars firstGoal;
    [SerializeField] GoalOfStars secondGoal;
    [SerializeField] GoalOfStars thirdGoal;
    Dictionary<GoalOfStars, System.Action> functionLookup;

    [Header("Set Count Of The Goals")]
    [SerializeField] List<int> maxCounts;

    [Header("Text Of The Goals")]
    [SerializeField] List<TextMeshProUGUI> goalTexts;

    [Header("Explanation Of The Goals")]
    [SerializeField] List<string> goalExplanationTexts;

    //float timeCount;
    public static int positiveCardCount, negativeCardCount;

    int index = 0;

    public static List<bool> goalCheck = new List<bool>();

    private void Awake()
    {
        functionLookup = new Dictionary<GoalOfStars, System.Action>()
        {
            {GoalOfStars.TimeTracking, TimeTracking },
            {GoalOfStars.UsePositiveCard, UsePositiveCard },
            {GoalOfStars.UseNegativeCard, UseNegativeCard },
            {GoalOfStars.DontUseAnyCard, DontUseAnyCard },
            {GoalOfStars.DontUsePositiveCard, DontUsePositiveCard },
            {GoalOfStars.DontUseNegativeCard, DontUseNegativeCard },
            {GoalOfStars.CollectCoin, CollectCoin }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        positiveCardCount = 0;
        negativeCardCount = 0;
        for(int i = 0; i < goalTexts.Count; i++)
        {
            goalCheck.Add(false);
        }
        //ActivateSelectedFunction();
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameController.gameState == GameState.Playing) timeCount += Time.deltaTime;
        ActivateSelectedFunction();
    }

    public void ActivateSelectedFunction()
    {
        functionLookup[firstGoal].Invoke();
        functionLookup[secondGoal].Invoke();
        functionLookup[thirdGoal].Invoke();
    }

    void TimeTracking()
    {
        goalTexts[index].text = goalExplanationTexts[index] + TimeManager.count.ToString("0") + "/" + maxCounts[index].ToString("0");
        if(TimeManager.count > maxCounts[index]) goalTexts[index].fontStyle = FontStyles.Strikethrough;
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal((int)TimeManager.count, maxCounts[index], 1);

        SetIndex();
    }

    void UsePositiveCard()
    {
        goalTexts[index].text = goalExplanationTexts[index] + positiveCardCount.ToString() + "/" + maxCounts[index].ToString();
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal(positiveCardCount, maxCounts[index], 0);

        SetIndex();
    }

    void UseNegativeCard()
    {
        goalTexts[index].text = goalExplanationTexts[index] + negativeCardCount.ToString() + "/" + maxCounts[index].ToString();
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal(negativeCardCount, maxCounts[index], 0);

        SetIndex();
    }

    void DontUseAnyCard()
    {
        goalTexts[index].text = goalExplanationTexts[index] + positiveCardCount.ToString() + "/" + maxCounts[index].ToString();
        if (positiveCardCount > maxCounts[index]) goalTexts[index].fontStyle = FontStyles.Strikethrough;
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal(positiveCardCount, maxCounts[index], 1);

        SetIndex();
    }

    void DontUsePositiveCard()
    {
        goalTexts[index].text = goalExplanationTexts[index] + positiveCardCount.ToString() + "/" + maxCounts[index].ToString();
        if (positiveCardCount > maxCounts[index]) goalTexts[index].fontStyle = FontStyles.Strikethrough;
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal(positiveCardCount, maxCounts[index], 1);

        SetIndex();
    }

    void DontUseNegativeCard()
    {
        goalTexts[index].text = goalExplanationTexts[index] + negativeCardCount.ToString() + "/" + maxCounts[index].ToString();
        if (negativeCardCount > maxCounts[index]) goalTexts[index].fontStyle = FontStyles.Strikethrough;
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal(negativeCardCount, maxCounts[index], 1);

        SetIndex();
    }

    void CollectCoin()
    {
        goalTexts[index].text = goalExplanationTexts[index] + CoinManager.coinCount.ToString() + "/" + maxCounts[index].ToString();
        if (GameController.gameState == GameState.Finish) goalCheck[index] = CheckGoal(PointManager.coinValue, maxCounts[index], 0);

        SetIndex();
    }

    bool CheckGoal(int count, int maxCount, int caseIndex)
    {
        switch (caseIndex)
        {
            case 0:
                if (count >= maxCount) return true;
                else return false;
            case 1:
                if (count <= maxCount) return true;
                else return false;
            default:
                return false;
        }
    }

    void SetIndex()
    {
        if (index < goalTexts.Count - 1) index++;
        else index = 0;
    }

}
