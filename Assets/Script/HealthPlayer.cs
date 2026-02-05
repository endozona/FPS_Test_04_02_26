using UnityEngine;

public class HealthPlayer: MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    
    public void PlayerDammage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Destroy (gameObject);
    }
}