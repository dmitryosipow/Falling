using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScorePickup : MonoBehaviour
{
    public int points;

    void ApplyEffect()
    {
        GameManager gM = FindObjectOfType<GameManager>();
        gM.UpdateScore(points);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
}
