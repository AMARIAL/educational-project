using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action healthChanged;
    public event Action healthDamage;
    public event Action isDead;
    
    [SerializeField] private bool isActive;
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;

    public void Start()
    {
        GameManager.ST.healthContainer.Add(gameObject, this);
        Resurrection();
    }
    public void Resurrection()
    {
        isActive = true;
        DoHeal(maxHealth);
    }
    public void TakeDamage(int dmg)
    {
        if(!isActive) return;
        
        currentHealth -= dmg;
        
        if (currentHealth > 0) 
            return;

        CheckIsAllive();
        isActive = false;
        Invoke(nameof(Activate), 1.0f);
        
        healthDamage?.Invoke();
    }

    private void CheckIsAllive()
    {
        if (currentHealth <= 0)
        {
            isDead?.Invoke();
            Destroy(gameObject);
        }
    }
    public void DoHeal(int dmg)
    {
        currentHealth += dmg;
        
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        healthChanged?.Invoke();
    }

    private void Activate()
    {
        isActive = true;
    }
    
}
