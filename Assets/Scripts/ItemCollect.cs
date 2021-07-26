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
            stats.points += itemPoints;
            Debug.Log(stats.points);
            stats.pointsText.text = "Points: " + stats.points;
            Destroy(this.gameObject);
        }
    }
}
