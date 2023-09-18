using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

    public class Health : MonoBehaviour
{
    public Image lifebar;
    public Image redBar;

    public int health;
    public int maxHealth = 10;

    public string hitedBy;

    // Player sofrer dano
    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
            health = 0;
        }

        Vector3 lifebarScale = lifebar.rectTransform.localScale;
        lifebarScale.x = (float)health / maxHealth;
        lifebar.rectTransform.localScale = lifebarScale; 
        StartCoroutine(DecreasingRedBar(lifebarScale));
    }

    IEnumerator DecreasingRedBar(Vector3 newScale)
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 redBarScale = redBar.transform.localScale;
        while (redBar.transform.localScale.x > newScale.x)
        {
            redBarScale.x -= Time.deltaTime * 0.25f;
            redBar.transform.localScale = redBarScale;

            yield return null;
        }

        redBar.transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == hitedBy)
        {
            TakeDamage(damage);
        }
    }
}

