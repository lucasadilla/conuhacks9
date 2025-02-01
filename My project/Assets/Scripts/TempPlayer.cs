using Unity.Netcode;
using UnityEngine;


public class TempPlayer : NetworkBehaviour
{
    [SerializeField] float moveSpeed = 4;

    [SerializeField] Transform sprites;

    Animator animator;
    Rigidbody2D rb;

    float moveHorizontal, moveVertical;
    Vector2 movement;

    int facingDirection = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        Move();
    }

    void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.linearVelocity = movement * moveSpeed;

        if (movement.x != 0)
        {
            facingDirection = movement.x > 0 ? 1 : -1;
        }
        sprites.localScale = new Vector2(facingDirection, 1);
        //animator.SetFloat("velocity", movement.magnitude);
    }
}
