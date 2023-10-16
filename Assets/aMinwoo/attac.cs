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
        // 초기화 또는 설정
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
        EnableMeleeArea(true); // 공격 영역 활성화

        // 첫 번째 공격
        animator.SetBool("punch1", true);
        yield return new WaitForSeconds(rate);
        animator.SetBool("punch1", false);

        yield return new WaitForSeconds(rate); // 두 번째 공격의 시간 지연

        // 두 번째 공격
        animator.SetBool("punch2", true);
        yield return new WaitForSeconds(rate);
        animator.SetBool("punch2", false);

        EnableMeleeArea(false); // 공격 영역 비활성화

        isAttacking = false;
    }

    void EnableMeleeArea(bool enabled)
    {
        meleeArea.enabled = enabled;
    }
}