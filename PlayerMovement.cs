using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body; 
    void Start()
    {
        
    }
    void Update()
    {
        float xInput = Input. GetAxis ("Horizontal");
        float yInput = Input. GetAxis ("Vertical");
        body.linearVelocity = new Vector2(xInput, yInput) ;
    }
}
