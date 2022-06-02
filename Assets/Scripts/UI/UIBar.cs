using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBar : UIBaseWidget
{
    [SerializeField] RectTransform _bar;
    
    public void ShowProgress(float fillAmount)
    {
        fillAmount = Mathf.Clamp(fillAmount, 0, 1);
        _bar.sizeDelta = new Vector2(_bar.sizeDelta.x * fillAmount, _bar.sizeDelta.y);
    }
}
