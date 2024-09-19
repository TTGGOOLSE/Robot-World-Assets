using System.Collections;
using Systen.Collections.Generic;
using UnityEngine;

public BoostPad : MonoBehaviour
{
    public Rigbody GorillaPlayer;

    public int Xforce

    // Start is called before first frame update
    void Start()

    // Update is called once before first frame update
    void Update()
    {
        if (EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
        {
            GorillaPlayer.Addforce(XForce, ForceMode.Acceleration);
        }
    }
}