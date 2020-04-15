using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBomb : ObjectPool
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform _theMainSpawner;
    [SerializeField] private float _secondsBetweenSpawn;

    private Transform[] _spawnPoints;
    private float _elapsedTime = 0;
    private float _elapsedTimeBeforeSpawn = 0;

    private void Start()
    {
        _spawnPoints = new Transform[_theMainSpawner.childCount];

        for (int i = 0; i < _theMainSpawner.childCount; i++)
        {
            _spawnPoints[i] = _theMainSpawner.GetChild(i);
        }

        Initialize(_bombPrefab);
    }

    private void Update()
    {
        _elapsedTimeBeforeSpawn += Time.deltaTime;
        _elapsedTime += Time.deltaTime;

        if (_elapsedTimeBeforeSpawn > 1.3)
        {
            if (_elapsedTime >= _secondsBetweenSpawn)
            {
                if (TryGetObject(out GameObject bomb))
                {
                    _elapsedTime = 0;

                    int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                    SetBomb(bomb, _spawnPoints[spawnPointNumber].position);
                }
            }
        }
    }

    private void SetBomb(GameObject bomb, Vector3 spawnPoint)
    {
        bomb.SetActive(true);
        bomb.transform.position = spawnPoint;
    }
}
