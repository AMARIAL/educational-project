using UnityEngine;

public class BulletEye : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        gameObject.SetActive(false);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Shoot(Transform eye)
    {
        transform.position = eye.position;
        gameObject.SetActive(true);
        _rigidbody2D.AddForce(eye.localScale*speed,ForceMode2D.Impulse);
        Invoke(nameof(Return),1.5f);
    }

    private void Return()
    {
        gameObject.SetActive(false);
        _rigidbody2D.velocity = Vector3.zero;
    }

}
