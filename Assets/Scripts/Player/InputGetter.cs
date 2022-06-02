using UnityEngine;
using UnityEngine.Events;

public class InputGetter : MonoBehaviour
{
    public UnityEvent<Vector3> Touch;
    private bool isStop;

    private InputsSystem _inputs;
    private void Awake()
    {
        _inputs = new InputsMultiPlatform();
    }
    void Update()
    {
        if (isStop) return;
        if(_inputs.DownClick()) Touch.Invoke(Input.mousePosition);
    }
    public void Stop()
    {
        isStop = true;
    }
    public void Continue()
    {
        isStop = false;
    }
}
