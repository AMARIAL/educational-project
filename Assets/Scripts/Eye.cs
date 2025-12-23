using System.Collections;
using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] private bool isAlive;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private BulletEye bullet;
    [SerializeField] private bool isLookRight = true;
    private Vector3 currentTarget;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Health _health;
    
    private void Awake ()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }
    private void Start()
    {
        isAlive = true;
        currentTarget = endPoint.position;
        //eyeBullet.gameObject.SetActive(false);
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if(isAlive)
            Move();
    }
    
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed*Time.deltaTime);
        
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentTarget = (currentTarget == endPoint.position) ? startPoint.position : endPoint.position;
        }

        Flip();
    }

    private void Flip()
    {
        float px = Player.ST.transform.position.x;
        float x = transform.position.x;
        if (px < x && isLookRight || px > x && !isLookRight)
        {
            isLookRight = !isLookRight;
            transform.localScale = new Vector3(isLookRight ? 1 : -1, 1, 1);
        }
    }

    private IEnumerator Shoot()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(2.0f);
            _animator.SetTrigger("trShoot");
        }
        yield return null; 
    }

    public void Attack()
    {
        bullet.Shoot(transform);
    }
}
