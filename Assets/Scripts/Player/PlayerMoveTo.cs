using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerUsingGun), typeof(NavMeshAgent), typeof(Animator))]
public class PlayerMoveTo : MonoBehaviour
{
    private PlayerUsingGun _usingGun;
    private Animator _animator;
    private NavMeshAgent _navAgent;
    void Start()
    {
        _usingGun = GetComponent<PlayerUsingGun>();
        _animator = GetComponent<Animator>();
        _navAgent = GetComponent<NavMeshAgent>();
    }
    //public void MoveTo(Vector3 position); overload if it will have need
    public void MoveTo(Vector3 position, Action completeMoving = null)
    {
        _usingGun.SetReadyFire(false);
        _navAgent.SetDestination(position);
        _animator.SetTrigger("Run");
        StartCoroutine(StopMoving(completeMoving));
    }

    private IEnumerator StopMoving(Action completeMoving)
    {
        yield return new WaitForSeconds(2);
        while (_navAgent.velocity != Vector3.zero)
        {
            yield return null;
        }
        _animator.SetTrigger("Idle");
        _usingGun.SetReadyFire(true);
        if (completeMoving != null) completeMoving.Invoke();
    }
}
