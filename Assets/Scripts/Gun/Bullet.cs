using System;
using UnityEngine;
//rigidbody on every bullet...

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IResetable
{
    public event Action<Bullet> DestroyDelegate = delegate { };
    [SerializeField] float _speed;
    [SerializeField] float _forceStrike = 100;

    private float _destroyTime = 10;
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if(_destroyTime < 0)
        {
            SelfDestroy();
        }
        else if(_destroyTime > 0)
        {
            _destroyTime -= Time.deltaTime;
        }
    }

    private void SelfDestroy()
    {
        DestroyDelegate.Invoke(this);
        _destroyTime = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamageable damageable)){
            damageable.Hit();
            
        }
        SelfDestroy();
    }

    public void Reset()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = Vector3.zero;
        DestroyDelegate = delegate { };
        _destroyTime = 10;
    }
}
