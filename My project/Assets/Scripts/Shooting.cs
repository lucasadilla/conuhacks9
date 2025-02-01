using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D bullet;
    public GameObject impactEffect;
    void Start()
    {
 
    }
    void Update()
    {
        bullet.linearVelocity = new Vector2(1,0) * movespeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(bullet.gameObject);
        
        Instantiate(impactEffect, transform.position, Quaternion.identity);
    }
}