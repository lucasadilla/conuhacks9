using UnityEngine;

public class Shooting
{
    public GameObject bulletPrefab; // Prefab of the bullet to shoot
    public Transform firePoint;     // Point from where the bullet will be fired
    public float bulletForce = 20f; // Speed of the bullet

    void Update()
    {
        // Rotate the player to face the mouse position
        Aim();

        // Check for mouse click to shoot
        if (Input.GetButtonDown("Fire1")) // "Fire1" is the left mouse button by default
        {
            Shoot();
        }
    }

    void Aim()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is 0 for 2D

        // Calculate the direction from the player to the mouse position
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle to rotate the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player to face the mouse position
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply force to the bullet in the direction of the fire point
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}