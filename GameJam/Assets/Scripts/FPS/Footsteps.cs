using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    CharacterController cc;
    AudioSource audios;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audios = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(cc.velocity.magnitude > 1f && audios.isPlaying == false)
        {
            audios.Play();
        }
    }
}
