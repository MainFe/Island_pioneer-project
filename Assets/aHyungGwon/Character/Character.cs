using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //movement
    public float speed = 5f;
    Rigidbody character_body;

    //animaiton
    Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        character_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        //movement
        Vector3 velocity = new Vector3(inputX, 0, inputZ).normalized;
        character_body.velocity = velocity*speed;
        transform.LookAt(transform.position+velocity);

        //animation
        anim.SetBool("isWalk", velocity!=Vector3.zero);
    }
}
