using UnityEngine;

public enum OtherHealthOwner: byte
{
    Enemy,
    Player
}
public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private OtherHealthOwner otherHealthOwner;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(otherHealthOwner.ToString()))
        {
            GameManager.ST.healthContainer[other.gameObject].TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}