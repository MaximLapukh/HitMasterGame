using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UICoverScreen : UIBaseWidget
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public override void Show()
    {
        gameObject.SetActive(true);
        _animator.SetTrigger("Show");
    }
    public void AllreadyShow()
    {
        base.AllreadyShow();
    }
    public override void Hide()
    {
        _animator.SetTrigger("Hide");
    }
    public void AllreadyHide()
    {
        base.AllreadyHide();
    }
}
