using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("pickup"))
        {
            UpdateScorePickup obj = collision.gameObject.GetComponent<UpdateScorePickup>();

            if (obj && obj.points > 0)
            {
                gameManager.ChangeHealth(-1);
            }
        }

        Destroy(collision.gameObject);
    }
}
