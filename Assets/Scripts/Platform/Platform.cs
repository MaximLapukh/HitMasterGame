using System;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action AllEnemyHitEvent = delegate { };
    [SerializeField] Transform _cameraPoint;
    [SerializeField] Transform _playerPoint;
    [SerializeField] List<EnemyHits> _enemies;
    private void Start()
    {
        foreach (var item in _enemies)
        {
            item.DieEvent += ProcessHit;
        }
    }

    private void ProcessHit(EnemyHits enemyHits)
    {
        _enemies.Remove(enemyHits);
        if(_enemies.Count == 0) 
            AllEnemyHitEvent.Invoke();
    }

    public Transform GetCameraPoint()
    {
        return _cameraPoint;
    }
    public Transform GetPlayerPoint()
    {
        return _playerPoint;
    }
    public bool HaveEnemies()
    {
        return _enemies != null && _enemies.Count > 0;
    }
    private void OnDestroy()
    {
        AllEnemyHitEvent = null;
    }
}
