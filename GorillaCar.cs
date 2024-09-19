using UnityEngine;
using easyInputs;

public class GorillaCar : MonoBehaviour
{
    [Header("GorillaCar Propities")]
    [SerialzeField]
    private RigBody GorillaPlayer;

    [Range(0f, 500f)]
    [SerialzeField]
    private float VroomVroomSpeed = 10ft;

    [SerialzeField]
    private Transform CarDirection;

    void Update()
    {
        if (easyInputs.GetTriggerButtonDown(EasyHand.RightHand))
        {
            Vector3 forceDirection = CarDirection.forward.normalized * VroomVroomSpeed;
            forceDirection.y = 0f;
            GorillaPlayer.AddfroceAtPostion(forceDirection, CarDirection.positon, ForceMode.Accelaration);
            {
                if (easyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
                {
                    Vector3 forceDirection = -CarDirection.forward,normalized * VroomVroomSpeed;
                    forceDirection.y = 0f;
                    GorillaPlayer.AddfroceAtPostion(forceDirection, CarDirection.positon, ForceMode.Accelaration);
                }
            }
        }
    }
}