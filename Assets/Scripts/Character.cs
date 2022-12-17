using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        GameManager.ManagerInstance.Player = gameObject;
        _animator = GetComponentInChildren<Animator>();
        _animator.speed = 0;
        GameManager.ManagerInstance.OnPlayEvent += OnGameStart;
        GameManager.ManagerInstance.OnFailEvent += OnGameFail;
        GameManager.ManagerInstance.OnWinEvent += OnGameWin;
    }

    public void OnGameFail(object sender, EventArgs args)
    {
        _animator.SetInteger("State", 2);
    }

    public void OnGameWin(object sender, EventArgs args)
    {
        _animator.SetInteger("State", 1);
    }

    public void OnGameStart(object sender, EventArgs args)
    {
        _animator.speed = 1;
        _animator.SetInteger("State", 0);
    }

    public void StandUp()
    {
        _animator.Play("Walking");
        _animator.SetInteger("State", 0);
        _animator.speed = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.ManagerInstance.InvokeWinEvent();
        }

        if (collision.gameObject.CompareTag("Gold"))
        {
            GameManager.ManagerInstance.GoldCount += 1;
            GameManager.ManagerInstance.UpdateGoldText();
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.ManagerInstance.OnPlayEvent -= OnGameStart;
        GameManager.ManagerInstance.OnFailEvent -= OnGameFail;
        GameManager.ManagerInstance.OnWinEvent -= OnGameWin;
    }
}
