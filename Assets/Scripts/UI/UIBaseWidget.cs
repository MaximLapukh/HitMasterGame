using System;
using UnityEngine;

//couse have serialize
public abstract class UIBaseWidget : MonoBehaviour
{
    public event Action HadShowed = delegate { };
    public event Action HadHided = delegate { };
    public virtual void Show()
    {
        gameObject.SetActive(true);
        AllreadyShow();
    }
    protected void AllreadyShow()
    {
        HadShowed.Invoke();
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    protected void AllreadyHide()
    {
        HadHided.Invoke();
    }
    private void OnDestroy()
    {
        HadShowed = null;
        HadHided = null;
    }
}
