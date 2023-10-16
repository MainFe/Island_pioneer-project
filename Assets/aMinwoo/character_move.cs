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
    private void OnCollisionEnter(Collision collision)//�ٴ��� Ȯ���ϴ� ����
    {
        if(collision.gameObject.tag == "Floor")//�ٴڿ� Floor�±׸� �޾� �Է¹���
        {
            anim.SetBool("isJump", false);
            IsJump = false;
        }
    }
}
