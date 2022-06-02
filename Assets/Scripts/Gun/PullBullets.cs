using System.Collections.Generic;
using UnityEngine;

public class PullBullets: MonoBehaviour, IPullObjects<Bullet>
{
    [SerializeField] Bullet _prefBullter;
    private List<Bullet> _bullets = new List<Bullet>();
    public Bullet Create(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = null;
        bullet = Create();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    public Bullet Create()
    {
        Bullet bullet = null;

        if (_bullets.Count > 0)
        {
            bullet = _bullets[0];
            bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
            bullet.gameObject.SetActive(true);
            bullet.Reset();
            _bullets.Remove(bullet);
        }
        else
        {
            bullet = Instantiate(_prefBullter);
        }
        return bullet;
    }
    public void Destroy(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bullets.Add(bullet);
    }
}
