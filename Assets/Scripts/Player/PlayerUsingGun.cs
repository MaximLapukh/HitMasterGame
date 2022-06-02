using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerUsingGun : MonoBehaviour
{
    [SerializeField] Gun _gun;
    [SerializeField] Transform _aimingPoint;
    [SerializeField] Transform _holsterPoint;
    private bool _readyFire = true;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        UpdateReadyFire();
    }
   
    public void SetReadyFire(bool status)
    {
        _readyFire = status;
        UpdateReadyFire();
    }

    private void UpdateReadyFire()
    {
        if (_readyFire)
        {
            _gun.transform.position = _aimingPoint.position;
            _gun.transform.rotation = _aimingPoint.rotation;
        }
        else
        {
            _gun.transform.position = _holsterPoint.position;
            _gun.transform.rotation = _holsterPoint.rotation;
        }
    }

    public void FireTo(Vector3 screenPoint)
    {
        if (!_readyFire) return;

        var ray = Camera.main.ScreenPointToRay(screenPoint);
        var point = Vector3.zero;

        if(Physics.Raycast(ray, out RaycastHit hit))
            point = hit.point;
        else
            point = ray.GetPoint(50);
        
        var bodyLookVec = new Vector3(point.x - transform.position.x, 0, point.z - transform.position.z);
        transform.rotation = Quaternion.LookRotation(bodyLookVec);
        var gunLookVec = point - _gun.transform.position;
        _gun.transform.rotation = Quaternion.LookRotation(gunLookVec);

        _gun.Fire();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (_readyFire)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _gun.GetHandPoint().position);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _gun.GetHandPoint().rotation);
        }
        else
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        }
    }
 
}
