using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private NavMovement shadow;
    private AudioSource asPlayer;
    public AudioClip HeartBeatSound;

    public GameObject[] serverPrefabs;


    public Animator animTape;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    void OnTriggerStay(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;
        //Interact with the tape player
        if (collider.CompareTag("Tape Player"))
        {
            //Call for animations and audio as well as UI
            gameManager.instructionsPopUp.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                animTape.SetBool("StartStopTape", true);
                StartCoroutine(VariableDelayStart());
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                animTape.SetBool("Rewind", true);
                StartCoroutine(VariableDelayRewind());

            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                animTape.SetBool("SwitchTape", true);
                StartCoroutine(VariableDelaySwitch());
            }

            StartCoroutine(PopUpDelay());
        }
    }

    IEnumerator PopUpDelay()
    {
        yield return new WaitForSeconds(2);
        gameManager.instructionsPopUp.SetActive(false);
    }

    IEnumerator VariableDelayStart()
    {
        yield return new WaitForSeconds(20);
        animTape.SetBool("StartStopTape", false);
    }
    IEnumerator VariableDelayRewind()
    {
        yield return new WaitForSeconds(4);
        animTape.SetBool("Rewind", false);
    }
    IEnumerator VariableDelaySwitch()
    {
        yield return new WaitForSeconds(2);
        animTape.SetBool("SwitchTape", false);
    }
}
