using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform spawnSelect;
    public Transform spawnPlayer;
    public GameObject[] playerPrefabsselect;
    public GameObject[] playerPrefabs;
    public CameraHandler CameraHandler;
    private int index=0;
    private GameObject player;

    private void Awake()
    {
        CameraHandler.enabled = false;
      
    }

    private void Start()
    {
        player= Instantiate(playerPrefabsselect[index], spawnSelect.position, spawnSelect.rotation);
    }

    public void selectPlayer()
    {
        Destroy(player);
        CameraHandler.enabled = true;
        Instantiate(playerPrefabs[index], spawnPlayer.position, spawnPlayer.rotation);
        
    }
    
    public void next()
    {
        Destroy(player);
        index += 1;
        if (index > 1) index = 0;
        player= Instantiate(playerPrefabsselect[index], spawnSelect.position, spawnSelect.rotation);
    }
    
    public void previos()
    {
        Destroy(player);
        index -= 1;
        if (index<0) index = 1;
        player= Instantiate(playerPrefabsselect[index], spawnSelect.position, spawnSelect.rotation);
    }
    
    public void clothon()
    {
      GameObject.FindWithTag("Cloth").transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void clothoff()
    {
        GameObject.FindWithTag("Cloth").transform.GetChild(0).gameObject.SetActive(false);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
