using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlay : MonoBehaviour
{
    [SerializeField] InputGetter _playerInputs;
    [SerializeField] UIBaseWidget _tapToStart;

    private bool _hadStart;
    private InputsSystem _inputs;
    private void Awake()
    {
        _inputs = new InputsMultiPlatform();
    }
    private void Start()
    {
        _tapToStart.Show();
        _playerInputs.Stop();
    }
    private void LateUpdate()
    {
        if (_inputs.DownClick()) StartPlay();
    }
    public void StartPlay()
    {
        if (_hadStart) return;
        _playerInputs.Continue();
        _tapToStart.Hide();
        _hadStart = true;
    }
}
