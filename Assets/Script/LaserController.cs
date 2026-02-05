using System;
using Unity.VisualScripting;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private Transform _originTranform;
    
    private void Update()
    {
        Debug.DrawRay(_originTranform.position, _originTranform.forward * 100,  Color.red);
        if (Input.GetButtonDown("Fire1"))
        {
           Ray ray = new Ray(_originTranform.position, _originTranform.forward);

           if (Physics.Raycast(ray, out RaycastHit hit))
           {
               TargetController target = hit.collider.GetComponent<TargetController>();
               if (target != null) target.TakeDamage(1);
           }
           
           HealthPlayer health =  hit.collider.GetComponentInParent<HealthPlayer>();
           if (health != null) health.PlayerDammage(1);
        }
        
    }
}
// private void OnDrawGizmos(){
//     Gizmos.color = Color.red;
//     Gizmos.DrawRay(_originTranform.position, _originTranform.forward * 100);
// }