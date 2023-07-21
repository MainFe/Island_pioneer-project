using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEdInteract : MonoBehaviour
{
    Animator animator;
    Character character;
    public GameObject player;
    Rigidbody rigid;
    
    
    void Start()
    {
        animator = player.GetComponent<Animator>();
        character = player.GetComponent<Character>();
        rigid = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("IsSitting", true);
                player.transform.position = new Vector3(-10.5f, 3.5f, 29.6f);
                player.transform.rotation = Quaternion.Euler(new Vector3(0,-90,0));
                character.speed = 0;
                SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
