using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource attack2SFX;
    public AudioSource hit2SFX;

    public AudioSource attackSFX;
    public AudioSource hitSFX;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioPlays()
    {
        attack2SFX.Play();

        hit2SFX.Play();

        attackSFX.Play();

        hitSFX.Play();
    }
}
