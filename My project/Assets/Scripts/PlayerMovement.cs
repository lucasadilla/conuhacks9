using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float movspeed;
    public Rigidbody2D body;
    public Weapon weapon;
    float speed = 5;
    float speedX, speedY;
    public Transform firepoint;
    public GameObject bullet;
    public float timeBetweenShots;
    private float shotCounter;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!IsOwner && FindFirstObjectByType<NetworkManager>() != null) return;
        speedX = Input. GetAxisRaw("Horizontal") * speed;
        speedY = Input. GetAxisRaw ("Vertical") * speed;
        body.linearVelocity = new Vector2 (speedX , speedY);
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
        Vector2 mouseDistance = mousePos - screenPos;
        float angle = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetButton("Fire1"))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter > 0)
            {
                shotCounter = timeBetweenShots;
                Instantiate(bullet, firepoint.position, firepoint.rotation);
            }
        }
    }
}
