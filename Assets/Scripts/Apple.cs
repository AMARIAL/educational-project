using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private int hitpoints;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.ST.healthContainer[other.gameObject].DoHeal(hitpoints);
            gameObject.SetActive(false);
        }
    }
}
