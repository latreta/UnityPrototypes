using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Buff buffToApply;
    private StatusManager statusManager;
    private bool isToApplyBuff = false;

    private void Start()
    {
        statusManager = GetComponent<StatusManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isToApplyBuff = true;
        }
    }

    void FixedUpdate()
    {
        if (isToApplyBuff)
        {
            statusManager.ApplyBuff(buffToApply);
            isToApplyBuff = false;
        }
    }
}
