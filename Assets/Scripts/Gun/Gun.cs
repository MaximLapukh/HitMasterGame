using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _handPoint;

    [SerializeField] Bullet _prefabBullet;
    [SerializeField] Transform _bulletContainer;
    private PoolMonoBeh<Bullet> _poolBullets;
    private void Awake()
    {
        _poolBullets = new PoolMonoBeh<Bullet>(_prefabBullet, 5, _bulletContainer);
    }
    public void Fire()
    {
        var bullet = _poolBullets.TryGetMono();
        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = _firePoint.rotation;
        bullet.DestroyDelegate += DestroyBullet;
    }

    private void DestroyBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public Transform GetHandPoint() {
        return _handPoint;
    }
}
