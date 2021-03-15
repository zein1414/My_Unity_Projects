using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private ShooterScript assaultRifle;
  

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.InputController.Fire1)
        {
            assaultRifle.Fire();
        }
    }
}
