using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cam;

    public void ChangeLookPoint(Transform point, Transform position)
    {
        _cam.LookAt = point;
        _cam.Follow = position;
    }
}
