using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //references
    private static GameManager _instance;

    //getter and setter
    public static GameManager Instance => _instance;

    //parameters
    private int _width;
    private int _height;

    private void Awake() 
    {
        //create singleton of the manager
        if(_instance != null && _instance != this) Destroy(this);
        else {_instance = this; DontDestroyOnLoad(this);}    
    }
    
}
