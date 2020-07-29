using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator animator;

    public int damage;

    private Slider healthBar;

    public GameObject bossDeathFx, bossBlood;
    private void Start()
    {
        halfHealth = health / 2;
        animator = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.value = health;
        if (health <= 0)
        {
            Instantiate(bossDeathFx, transform.position, Quaternion.identity);
            Instantiate(bossBlood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            healthBar.gameObject.SetActive(false);
        }

        if(health <= halfHealth)
        {
            animator.SetTrigger("Running");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
