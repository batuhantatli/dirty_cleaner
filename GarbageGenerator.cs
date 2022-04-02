using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageGenerator : MonoBehaviour
{
    private float _dirtySpawnX;
    private float _dirtySpawnZ;
    private Vector3 _randomGarbageVector;
    public bool _canInstantiate;

    private int _int;


    [SerializeField] int _garbageCountLimit;
    [SerializeField] float _garbageSpawnSpeed;

    [SerializeField] Transform _garbageSpawnPoint;
    [SerializeField] Garbage _garbage;

    private Garbage _spawnedGarbageObj;

    private void Start()
    {
        StartCoroutine(GarbageSpawner());
    }


    IEnumerator GarbageSpawner()
    {
        while (_int < _garbageCountLimit)
        {
            GarbageCreator();
            yield return new WaitForSeconds(_garbageSpawnSpeed);
            _int++;
        }
    }


    private void GarbageCreator()
    {
        if (_canInstantiate)
        {
            GarbagePosition();
            _spawnedGarbageObj = Instantiate(_garbage, _garbageSpawnPoint.position, Quaternion.identity);
            _spawnedGarbageObj.transform.parent = _garbageSpawnPoint.transform;
            _spawnedGarbageObj.Shoot(_randomGarbageVector - _garbageSpawnPoint.position);
        }
    }

    public void GarbagePosition()
    {
        _dirtySpawnX = Random.Range(-6.5f, 6.5f);
        _dirtySpawnZ = Random.Range(-6.5f, 6.5f);
        _randomGarbageVector = new Vector3(_dirtySpawnX, .5f, _dirtySpawnZ);
        Debug.Log(_randomGarbageVector);
    }
}
