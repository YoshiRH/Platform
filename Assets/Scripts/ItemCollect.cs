using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public int itemPoints = 1;
    private PlayerStats stats;
    private Animator animator;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            stats = collision.GetComponent<PlayerStats>();
            stats.CollectedPoints(itemPoints);
            Destroy(this.gameObject);
        }
    }
}
