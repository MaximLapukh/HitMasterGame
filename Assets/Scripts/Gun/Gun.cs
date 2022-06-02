using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] PullBullets _pullBullets;
    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _handPoint;
    public void Fire()
    {
        var bullet = _pullBullets.Create(_firePoint.position, _firePoint.rotation);
        bullet.DestroyDelegate += DestroyBullet;
    }

    private void DestroyBullet(Bullet bullet)
    {
        _pullBullets.Destroy(bullet);
    }

    public Transform GetHandPoint() {
        return _handPoint;
    }
}
