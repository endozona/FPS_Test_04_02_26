using System;
using UnityEngine;

public class AmmoController: MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(DestroyMe), 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        TargetController target = other.GetComponent<TargetController>();
        if (target != null)
        {
           target.TakeDamage(2);
           Destroy(gameObject);
        }
        
        HealthPlayer hp = other.GetComponent<HealthPlayer>();
        if (hp != null)
        {
            hp.PlayerDammage(2);
            Destroy(gameObject);
        }
        
    }
    
    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}