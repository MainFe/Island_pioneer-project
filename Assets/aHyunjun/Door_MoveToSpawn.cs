using UnityEngine;

// �÷��̾ "Player" �±װ� �޷��־�� ��.
// Door��Ͽ� �ε�����, target�� ��ġ�� Player�� ���� ��.
public class Door_MoveToSpawn : MonoBehaviour
{
    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.transform.position = target.transform.position;
    }
}
