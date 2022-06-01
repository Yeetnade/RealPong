using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounceAudio : MonoBehaviour
{
    public AudioSource wallBounce;
    public AudioClip wallSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wallBounce.PlayOneShot(wallSound);
    }
}
