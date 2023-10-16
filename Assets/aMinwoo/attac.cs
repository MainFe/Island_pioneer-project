using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    private bool isAttacking = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        // �ʱ�ȭ �Ǵ� ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(PerformCombo());
        }
    }

    IEnumerator PerformCombo()
    {
        isAttacking = true;
        EnableMeleeArea(true); // ���� ���� Ȱ��ȭ

        // ù ��° ����
        animator.SetBool("punch1", true);
        yield return new WaitForSeconds(rate);
        animator.SetBool("punch1", false);

        yield return new WaitForSeconds(rate); // �� ��° ������ �ð� ����

        // �� ��° ����
        animator.SetBool("punch2", true);
        yield return new WaitForSeconds(rate);
        animator.SetBool("punch2", false);

        EnableMeleeArea(false); // ���� ���� ��Ȱ��ȭ

        isAttacking = false;
    }

    void EnableMeleeArea(bool enabled)
    {
        meleeArea.enabled = enabled;
    }
}