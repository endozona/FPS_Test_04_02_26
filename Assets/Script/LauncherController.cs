using System;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private float _ammoPower;
    [SerializeField] private GameObject _ammoPrefab;
    [SerializeField] private Transform _spawnPoint;
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject instantiate =  Instantiate(_ammoPrefab, _spawnPoint.position, Quaternion.identity);
            instantiate.GetComponent<Rigidbody>().AddForce(_spawnPoint.forward * _ammoPower);
        }
    }
}