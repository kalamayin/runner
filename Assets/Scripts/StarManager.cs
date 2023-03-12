using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{
    enum GoalOfStars
    {
        TimeTracking,
        UsePositiveCard,
        UseNegativeCard
    };
    [Header("Options of Goals")]
    [SerializeField] GoalOfStars firstGoal;
    [SerializeField] GoalOfStars secondGoal;
    [SerializeField] GoalOfStars thirdGoal;
    Dictionary<GoalOfStars, System.Action> functionLookup;

    [Header("Set The Goals")]
    [SerializeField] float timeGoal;
    [SerializeField] float positiveCardGoal;
    [SerializeField] float negativeCardGoal;

    [Header("Text Of The Goals")]
    [SerializeField] TextMeshProUGUI firstGoalText;
    [SerializeField] TextMeshProUGUI secondGoalText;
    [SerializeField] TextMeshProUGUI thirdGoalText;

    [Header("Explanation Of The Goals")]
    [SerializeField] string firstGoalExplanation;
    [SerializeField] string secondGoalExplanation;
    [SerializeField] string thirdGoalExplanation;

    float timeCount;
    public static float positiveCardCount, negativeCardCount;

    private void Awake()
    {
        functionLookup = new Dictionary<GoalOfStars, System.Action>()
        {
            {GoalOfStars.TimeTracking, TimeTracking },
            {GoalOfStars.UsePositiveCard, UsePositiveCard },
            {GoalOfStars.UseNegativeCard, UseNegativeCard }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
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
        
    }

    void UsePositiveCard()
    {
        Debug.Log("Positive");
    }

    void UseNegativeCard()
    {
        Debug.Log("Negative");
    }

}
