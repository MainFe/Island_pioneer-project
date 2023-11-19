using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool JDown;
    bool IsJump;
    bool IsFalling;
    Vector3 moveVec;
    Rigidbody rigid;
    Animator anim;
    void Awake()//에니매이션 받아서 실행 + Rigidbody 정보 저장
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        turn();
        Jump();
        falling();
    }
    void GetInput()//버튼 입력해서 동작하게 하는것
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        JDown = Input.GetButtonDown("Jump");
    }
    void Move()//움직임에 필요한 변수
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed*Time.deltaTime;
        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }
    void turn()//움직인 방향에 따른 캐릭터의 변화
    {
        transform.LookAt(transform.position + moveVec);
    }
    void Jump()//점프 변수
    {
        if(JDown && !IsJump)
        {
            rigid.AddForce(Vector3.up * 15,ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            IsJump = true;
        }
    }
    void falling()
    {
        
        if(rigid.velocity.y < 0)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isfalling", true);
            anim.SetTrigger("dofalling");
            IsFalling = true;
            IsJump = false;
        }
        if(rigid.velocity.y==0)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isfalling", false);
            IsFalling = false;
            IsJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)//바닥을 확인하는 변수
    {
        if(collision.gameObject.tag == "Floor")//바닥에 Floor태그를 달아 입력받음
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isfalling", false);
            IsFalling = false;
            IsJump=false;
        }
    }
}
