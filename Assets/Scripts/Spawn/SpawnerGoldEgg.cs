using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGoldEgg : ObjectPool
{
    [SerializeField] private GameObject _goldEggPrefab;
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

        Initialize(_goldEggPrefab);
    }

    private void Update()
    {
        _elapsedTimeBeforeSpawn += Time.deltaTime;
        _elapsedTime += Time.deltaTime;

        if (_elapsedTimeBeforeSpawn > 10f)
        {
            if (_elapsedTime >= _secondsBetweenSpawn)
            {
                if (TryGetObject(out GameObject goldEgg))
                {
                    _elapsedTime = 0;

                    int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                    SetBomb(goldEgg, _spawnPoints[spawnPointNumber].position);
                }
            }
        }
    }

    private void SetBomb(GameObject goldEgg, Vector3 spawnPoint)
    {
        goldEgg.SetActive(true);
        goldEgg.transform.position = spawnPoint;
    }
}
