using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private NavMovement shadow;
    private AudioSource asPlayer;
    public AudioClip HeartBeatSound;

    // Start is called before the first frame update
    void Start()
    {
        shadow = GameObject.Find("Shadow").GetComponent<NavMovement>();
        asPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shadow.CanTargetSeeMe())
        {
            asPlayer.PlayOneShot(HeartBeatSound, .1f);
        }
    }
}
