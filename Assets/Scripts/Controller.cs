using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 4;
    float rotationSpeed = 80;
    float rotation = 0f;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero; // => (0,0,0,); //move direction

    CharacterController controller;
    Animator anim; 
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)  //ako je na povrsini
        {
            if(Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3 (0, 0, 1);
              //moveDir = moveDir * speed;
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            else //kada prestanemo drzati w
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; //horizontal => a & d
        transform.eulerAngles = new Vector3 (0, rotation, 0);

        moveDir.y -= gravity * Time.deltaTime; // y=> up/down
        controller.Move(moveDir * Time.deltaTime);
    }
}
