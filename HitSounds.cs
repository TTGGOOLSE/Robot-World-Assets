using System.Collections;
using System.Collections.Generic;
using Unity Engine
public class HitSounds : MonoBehaviour
{
    public AudioSource HitSound;
    void OnTriggerEnter()
    {
        HitSound.Play();
    }
}