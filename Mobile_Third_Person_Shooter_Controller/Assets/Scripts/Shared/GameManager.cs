using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    //Evetn ro handel the PLayer Script
    public event System.Action<Player> OnStartPlayer;
    
    //game manager gameobject created on game start
    private GameObject gameObject;
    
    //Game Manger singelton 
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance=new GameManager();
                m_Instance.gameObject = GameObject.Find("GameManager");
            }

            return m_Instance;
        }
    }
    
    
    private InputController m_InputController;

    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }

    private Timer _timer;

    public Timer Timer
    {
        get
        {
            if(_timer==null)
                _timer=gameObject.GetComponent<Timer>();
            return _timer;
        }
    }

    private Respawner _respawner;

    public Respawner Respawner
    {
        get
        {
            if(_respawner==null)
                _respawner=gameObject.GetComponent<Respawner>();
            return _respawner;
        }
    }
    
    //PLaye in the game
    private Player m_player;

    public Player Player
    {
        get
        {
            return m_player;
        }
        set
        {
            m_player = value;
            if (OnStartPlayer != null)
                OnStartPlayer(m_player);
        }
    }


}
