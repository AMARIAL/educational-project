using System;
using UnityEngine;

public class HealthUiEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer healthBar;
    [SerializeField] private SpriteRenderer greenBar;
    [SerializeField] private Health health;
    
    private void Start()
    {
        //health.healthDamage += TakeDamage;
        healthBar.gameObject.SetActive(false);
    }

    private void TakeDamage()
    {
        healthBar.gameObject.SetActive(true);
        greenBar.transform.localScale = new Vector3((float)health.currentHealth/(float)health.maxHealth, 1,1);
        CancelInvoke();
        Invoke(nameof(inActive),5.0f);
    }

    private void inActive()
    {
        healthBar.gameObject.SetActive(false);
    }
    
}
