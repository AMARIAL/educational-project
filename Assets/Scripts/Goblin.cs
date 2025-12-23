using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isRight = true;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private bool isActive = true;
    
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckLimits();
        Move(isRight ? 1 : -1);
        Flip();
    }

    private void CheckLimits()
    {
        if (isRight && transform.position.x >= rightPoint.position.x || !isRight && transform.position.x <= leftPoint.position.x)
            isActive = false;
    }

    private void Move(int dir)
    {
        if(isActive)
            rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
    }

    private void Attack()
    {
        
    }

    private void Flip()
    {
        float px = Player.ST.transform.position.x;
        float x = transform.position.x;
        if (isRight && px < x  || !isRight && px > x)
        {
            isRight = !isRight;
            transform.localScale = new Vector3(isRight ? 1 : -1,1,1);
            isActive = true;
        }
    }
}
