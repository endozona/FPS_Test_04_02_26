using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer: MonoBehaviour
{
    
     [SerializeField] private float _currentHealth = 30f;
    private float maxHealth = 30f;
    public Image healthBar;
    public TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = _currentHealth + " / "  + maxHealth;
        healthBar.fillAmount = _currentHealth / maxHealth;
    }

    public void PlayerDammage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Destroy (gameObject);
    }
}