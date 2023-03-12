using System.Collections;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class PositiveCardsManager : MonoBehaviour
{
    [Header("Time Of Positive Talents")]
    [SerializeField] float superSpeedTime;
    [SerializeField] float superJumpTime;
    [SerializeField] float invisibleTime;
    [SerializeField] float dashTime;
    [SerializeField] float magnetTime;

    [Header("Coefficients For Effect")]
    [SerializeField] float speedCoeff;
    [SerializeField] float dashCoeff;
    [SerializeField] float teleportCoeff;

    [SerializeField] Vector3 dir;

    public delegate void PositiveEffects();

    public PositiveEffects positiveEffects;

    private void Start()
    {
        positiveEffects += SuperSpeed;
        positiveEffects += SuperJump;
        positiveEffects += Invisible;
        positiveEffects += Dash;
        positiveEffects += Magnet;
    }


    void SuperSpeed()
    {
        StartCoroutine(SuperSpeed(superSpeedTime));
    }

    void SuperJump()
    {
        PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        movement.playerRB.AddForce(dir * movement.jumpForce, ForceMode.Impulse);
    }

    void Invisible()
    {
        StartCoroutine(Invisible(invisibleTime));
    }

    void Dash()
    {
        StartCoroutine(Dash(dashTime));
    }

    void Magnet()
    {
        StartCoroutine(Magnet(magnetTime));
    }

    //public void Teleport()
    //{
    //    PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    //    //movement.playerRB.AddForce(Vector3.forward * movement.dashForce, ForceMode.Impulse);
    //    movement.highCoeff = 10f;
    //}

    public int ChooseRandomEffect(string name)
    {
        int random;
        if (name == "RandomlyPositive") random = Random.Range(0, positiveEffects.GetInvocationList().Length);
        else random = SetNumber(name);

        return random;
    }

    int SetNumber(string name)
    {
        int num = 0;
        if (name == "SuperSpeed") num = 0;
        else if (name == "SuperJump") num = 1;
        else if (name == "Invisible") num = 2;
        else if (name == "Dash") num = 3;
        else if (name == "Magnet") num = 4;
        return num;
    }


    IEnumerator SuperSpeed(float time)
    {
        PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        movement.highCoeff = speedCoeff;
        yield return new WaitForSeconds(time);
        movement.highCoeff = 1f;
    }

    IEnumerator Dash(float time)
    {
        PlayerMovement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        movement.highCoeff = dashCoeff;
        yield return new WaitForSeconds(time);
        movement.highCoeff = 1f;
    }

    IEnumerator Invisible(float time)
    {
        Rigidbody rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        CapsuleCollider collider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>();
        rb.useGravity = false;
        collider.isTrigger = true;
        yield return new WaitForSeconds(time);
        collider.isTrigger = false;
        rb.useGravity = true;
    }

    IEnumerator Magnet(float time)
    {
        CoinManager.magnet = true;
        yield return new WaitForSeconds(time);
        CoinManager.magnet = false;
    }

}
