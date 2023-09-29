using UnityEngine;

// 플레이어에 "Player" 태그가 달려있어야 함.
// Door블록에 부딪히면, target의 위치에 Player가 스폰 됨.
public class Door_MoveToSpawn : MonoBehaviour
{
    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.transform.position = target.transform.position;
    }
}
