using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player ST {get; private set;}
    
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D rb;
    private GroundDetection gd;

    private void Awake()
    {
        ST = this;
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetection>();
    }
    
    private void Update () {
        direction = new Vector2(0, rb.velocity.y);
        
        if (Input.GetKey(KeyCode.D))
            direction = Vector2.right;
        else if (Input.GetKey(KeyCode.A))
            direction = Vector2.left;

        if (Input.GetKey(KeyCode.Space) && gd.IsGrounded())
            Jump();

        Move(direction);
    }

    private void Move(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
}
