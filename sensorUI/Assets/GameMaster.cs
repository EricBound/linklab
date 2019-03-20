using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }

    }
    // Use this for initialization



    void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance != this)
        { //Whoever comes second, destroy yourself
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }



    public GameObject player;

    private void Start()
    {

    }
}