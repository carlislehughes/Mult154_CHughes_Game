using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector2 mInput = Vector2.zero;

    public float mouseSensitivity = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        //Mouse Inputs
        mInput.y += Input.GetAxis("Mouse X");
        mInput.x += -Input.GetAxis("Mouse Y");


        //moving
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verMove);
        //strafing
        transform.Translate(Vector3.right * Time.deltaTime * speed * horMove);

        //mouse look
        mInput.x = Mathf.Clamp(mInput.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, mInput.y) * mouseSensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(mInput.x * mouseSensitivity, 0, 0);

        /**
         * source for mouse look: https://www.reddit.com/r/Unity3D/comments/8k7w7v/unity_simple_mouselook/
         **/
        
    }
}
