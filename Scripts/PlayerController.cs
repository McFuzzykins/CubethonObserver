using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    private CameraController _camCont;
    public bool flip
    {
        get; private set;
    }

    private ClientStrat _client;
    public bool obs
    {
        get; private set;
    }

    void Awake()
    {
        _camCont = (CameraController)FindObjectOfType(typeof(CameraController));
        _client = (ClientStrat)FindObjectOfType(typeof(ClientStrat));
    }

    void OnTriggerEnter()
    {
        
        Debug.Log("Flip 1");
        ToggleFlip();
        SpawnObs();
       
    }

    void OnEnable()
    {
        if(_camCont)
        {
            Attach(_camCont);
        }

        if(_client)
        {
            Attach(_client);
        }
    }

    void OnDisable()
    {
        if(_camCont)
        {
            Detach(_camCont);
        }

        if(_client)
        {
            Detach(_client);
        }
    }

    public void ToggleFlip()
    {
        flip = !flip;
        NotifyObservers();
    }

    public void SpawnObs()
    {
        obs = !obs;
        NotifyObservers();
    }
}
