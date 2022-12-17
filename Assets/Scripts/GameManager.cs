using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private GameObject startText;
    
    private bool _gameOn = false;
    private int _goldCount = 0;
    private bool _hasWon = false;

    public event EventHandler OnFailEvent;
    public event EventHandler OnPlayEvent;
    public event EventHandler OnWinEvent;

    private GameObject _player;
    
    private static GameManager _instance;
    
    public static GameManager ManagerInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
        private set { _instance = value; }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void InvokePlayEvent()
    {
        startText.SetActive(false);
        _gameOn = true;
        _hasWon = false;
        OnPlayEvent?.Invoke(this, EventArgs.Empty);
    }
    
    public void InvokeFailEvent()
    {
        _gameOn = false;
        OnFailEvent?.Invoke(this, EventArgs.Empty);
        StartCoroutine(ResetIn(2));
        
    }
    
    public void InvokeWinEvent()
    {
        _gameOn = false;
        OnWinEvent?.Invoke(this, EventArgs.Empty);
        StartCoroutine(LoadIn(2));
        Debug.Log("Win event called");
    }

    void Update()
    {
        if (_gameOn) return;
        
        if (Input.anyKeyDown)
        {
            InvokePlayEvent();
        }
    }

    IEnumerator LoadIn(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    IEnumerator ResetIn(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _player.transform.position = Vector3.zero;
        _player.GetComponent<CubeSurf>().ResetCubes();
        _player.GetComponent<Character>().StandUp();
    }

    public void UpdateGoldText()
    {
        goldText.text = "x " + GoldCount;
    }
    
    public bool GameOn
    {
        get => _gameOn;
        set => _gameOn = value;
    }

    public bool HasWon
    {
        get => _hasWon;
        set => _hasWon = value;
    }

    public int GoldCount
    {
        get => _goldCount;
        set => _goldCount = value;
    }

    public GameObject Player
    {
        get => _player;
        set => _player = value;
    }
}
