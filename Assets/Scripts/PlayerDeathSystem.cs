using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathSystem : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Death();
        }
    }

    public void Death()
    {
        animator.SetTrigger("isDead");
        rb.bodyType = RigidbodyType2D.Static;
        deathSound.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
