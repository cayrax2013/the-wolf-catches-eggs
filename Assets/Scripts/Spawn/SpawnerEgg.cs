using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEgg : ObjectPool
{
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private Transform _theMainSpawner;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private int _delayBetweenRiseSpeedSpawn = 1;

    private Transform[] _spawnPoints;
    private float _elapsedTime = 0;

    private void Start()
    {
        _spawnPoints = new Transform[_theMainSpawner.childCount];

        for (int i = 0; i < _theMainSpawner.childCount; i++)
        {
            _spawnPoints[i] = _theMainSpawner.GetChild(i);
        }

        Initialize(_eggPrefab);

        StartCoroutine(ToIncreaseTheSpeedOf());
    }

    private IEnumerator ToIncreaseTheSpeedOf()
    {
        var secondsWaitForSeconds = new WaitForSeconds(_delayBetweenRiseSpeedSpawn);

        while (true)
        {
            if (_secondsBetweenSpawn > 0.5350004f)
                _secondsBetweenSpawn -= 0.005f;
            else
                _secondsBetweenSpawn -= 0.0005f;

            yield return secondsWaitForSeconds;
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject egg))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEgg(egg, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEgg(GameObject egg, Vector3 spawnPoint)
    {
        egg.SetActive(true);
        egg.transform.position = spawnPoint;
    }
}
