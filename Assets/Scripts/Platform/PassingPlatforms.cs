using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PassingPlatforms : MonoBehaviour
{
    public UnityEvent OverPlatforms;
    [SerializeField] List<Platform> _platforms; //mb better make stack or handler
    [SerializeField] PlayerMoveTo _playerMove;
    [SerializeField] CameraLook _cameraLook;
    private void Start()
    {
        _platforms[0].AllEnemyHitEvent += GoNext;
    }

    private void GoNext()
    {
        var platform = _platforms[0];
        _playerMove.MoveTo(platform.GetPlayerPoint().position, SetupNext);
        _cameraLook.ChangeLookPoint(platform.GetCameraPoint(), platform.GetPlayerPoint());
        platform.AllEnemyHitEvent -= GoNext;
        _platforms.Remove(platform);
    }
    private void SetupNext()
    {
        if (_platforms.Count > 0)
        {
            if (_platforms[0].HaveEnemies())
                _platforms[0].AllEnemyHitEvent += GoNext;
            else
                GoNext();
        }
        else
        {
            OverPlatforms.Invoke();
        }
    }
   
}
