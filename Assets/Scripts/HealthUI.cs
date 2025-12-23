using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image greenLine;
    private Health playerHealth;

    private void Start()
    {
        if (Player.ST)
            playerHealth = Player.ST.GetComponent<Health>();
        
        playerHealth.healthChanged += ChangeHp;
        playerHealth.healthDamage += DamageHp;
        playerHealth.isDead += Dead;
    }

    private void ChangeHp()
    {
        Debug.Log("Лечение!");
    }
    private void DamageHp()
    {
        Debug.Log("Нанесли урон!");
    }
    private void Dead()
    {
        Menu.ST.GameOver();
    }
}
