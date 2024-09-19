using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnableCosmetic ; ManoBehaviour
{
    [Header("Set this to object you want to enable.")]
    public GameObject objectEnable;

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "HandTag")
        {
            Debug.Log("Object Enable.");
            {
            }
              ObjectToEnable.SetActive(true);
        }
    }
}