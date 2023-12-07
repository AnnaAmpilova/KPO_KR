using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEmoji : MonoBehaviour
{
    public GameObject deathEffect;

    public float health = 4f;

    public static int BlueEmojisAlive = 0;

    void Start()
    {
        BlueEmojisAlive++;
    }
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        BlueEmojisAlive--;
        if (BlueEmojisAlive <= 0)
            Debug.Log("LEVEL 1");
        Destroy(gameObject);
    }
}
