using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMonoBeh<T> where T : MonoBehaviour, IResetable
{
    private readonly T _prefab;
    private readonly Transform _container;
    private List<T> _pool;
    public PoolMonoBeh(T prefab, int sizePool, Transform container = null)
    {
        _prefab = prefab;
        _container = container;

        CreatePool(sizePool);
    }

    private void CreatePool(int sizePool)
    {
        _pool = new List<T>();
        for (int i = 0; i < sizePool; i++)
        {
            CreateMono(false);
        }
    }

    private T CreateMono(bool activeByDefault)
    {
        var mono = GameObject.Instantiate(_prefab, _container);
        mono.gameObject.SetActive(activeByDefault);
        _pool.Add(mono);
        return mono;
    }
    private bool HasPoolMono(out T mono)
    {
        foreach (var monoItem in _pool)
        {
            if (!monoItem.gameObject.activeInHierarchy)
            {
                monoItem.gameObject.SetActive(true);
                mono = monoItem;
                return true;
            }
        }
        mono = null;
        return false;
    }
    public T TryGetMono()
    {
        T resultMono = null;
        if(HasPoolMono(out T mono))
            resultMono = mono;
        else 
            resultMono = CreateMono(true);

        resultMono.Reset();
        return resultMono;
    }
}
