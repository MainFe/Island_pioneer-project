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
    void Awake()//���ϸ��̼� �޾Ƽ� ���� + Rigidbody ���� ����
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
    void GetInput()//��ư �Է��ؼ� �����ϰ� �ϴ°�
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        JDown = Input.GetButtonDown("Jump");
    }
    void Move()//�����ӿ� �ʿ��� ����
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed*Time.deltaTime;
        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }
    void turn()//������ ���⿡ ���� ĳ������ ��ȭ
    {
        transform.LookAt(transform.position + moveVec);
    }
    void Jump()//���� ����
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
    private void OnCollisionEnter(Collision collision)//�ٴ��� Ȯ���ϴ� ����
    {
        if(collision.gameObject.tag == "Floor")//�ٴڿ� Floor�±׸� �޾� �Է¹���
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isfalling", false);
            IsFalling = false;
            IsJump=false;
        }
    }
}
