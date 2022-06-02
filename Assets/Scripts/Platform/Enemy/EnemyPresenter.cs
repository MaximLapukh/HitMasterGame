using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] EnemyHits _enemyHits;
    [SerializeField] UIBar _hpBar;
    void Start()
    {
        _enemyHits.ChangeAmountHP += ShowHP;
    }

    private void ShowHP(float fillAmount)
    {
        if (fillAmount <= 0) _hpBar.Hide();
        else _hpBar.ShowProgress(fillAmount);
    }
}
