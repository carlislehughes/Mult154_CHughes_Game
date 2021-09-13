using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Rigidbody rbPlayer;
   // private Vector3 direction = Vector3.zero;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");


        //moving
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verMove);
        //turning
        transform.Rotate(Vector3.up, Time.deltaTime * 100.0f * horMove);

        //direction = new Vector3(horMove, 0, verMove);
    }
    //void FixedUpdate()
    //{

   //     rbPlayer.AddForce(direction * speed, ForceMode.Force);
    //}
}
