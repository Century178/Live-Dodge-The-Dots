using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _yTop, _yBottom; //You can declare any amount of a type in one statement.

    [SerializeField] private Obstacle _obstacle; //A script instance counts as an object.

    [Header("Spawning")] //Headers help organize scripts in the inspector.
    [SerializeField] private float _spawnRate = 4f;
    [SerializeField] private float _spawnDelay; //Make sure to set one spawner's delay higher.
    [SerializeField] private float _spawnRateMin = 1f;
    [SerializeField] private float _rampUp = 0.05f;
    private float _spawnTime;

    private void Update()
    {
        if (_spawnDelay > 0)
        {
            _spawnDelay -= Time.deltaTime;
            return; //Skip every line after this one in the method.
        }

        _spawnTime -= Time.deltaTime;

        if (_spawnTime <= 0)
        {
            _spawnTime = _spawnRate;

            if (_spawnRate > _spawnRateMin) _spawnRate -= _rampUp;

            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(_yTop, _yBottom), transform.position.z);
            Instantiate(_obstacle, spawnPos, transform.rotation); //There will be two spawners, so we use transform.rotation.
        }
    }
}
