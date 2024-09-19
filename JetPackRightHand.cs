using System.Collections;
using System.Collections.Generic;
using UnityEngine


public class JetPack : MonoBehaviour;
{
    public Rigidbody GorillaPlayer;
    
    public int Xforce;
    public int YFocrce
    public int Zforce;

    // Start is called begore first frame update
    void Start()
    {

    }
    
    //Update is called once before first frame
    void Update()
    {
        if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
        {
            GorillaPlayer.Addforce(Xforce, Zforce, ForceMode.Acceleration);
     
       }
    }
}
