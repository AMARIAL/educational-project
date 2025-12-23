using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 dir, int bulletSpeed)
    {
        gameObject.SetActive(true);
        rb.AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(Clear());
    }
    
    private IEnumerator  Clear ()
    {
        yield return new WaitForSeconds(3.0f); 
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
        yield return null;
    }
}
