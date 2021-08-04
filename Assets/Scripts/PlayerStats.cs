using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int points = 0;
    public Text pointsText;

    [SerializeField] AudioSource collectSound;

    public void CollectedPoints (int pointsFromItem)
    {
        points += pointsFromItem;
        collectSound.Play();
        pointsText.text = "Points: " + points;
    }
}
