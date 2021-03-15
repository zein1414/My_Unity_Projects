using System;
using System.Collections;
using System.Collections.Generic;
using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
  //PLayer Input values  
  public float Vertical;
  public float Horizontal;
  public Vector2 MouseInput;
  public bool Fire1;
  public bool Reload;
  //joystick to handle playr input values
  private Joystick _joystick;
  private Joystick _joystickRotate;
  
  private void Awake()
  {
    _joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
    _joystickRotate=GameObject.Find("JoystickRotate").GetComponent<Joystick>();
  }

  private void Update()
  {
#if  UNITY_ANDROID
    Vertical = _joystick.yAxis.value;// Input.GetAxis("Vertical");
    Horizontal = _joystick.xAxis.value;//Input.GetAxis("Horizontal");
    MouseInput=new Vector2(_joystickRotate.xAxis.value,_joystickRotate.yAxis.value);
    //Fire1=Input.GetButton("Fire1");
   // Reload = Input.GetKey(KeyCode.R);
#else
    Vertical = Input.GetAxis("Vertical");
    Horizontal = Input.GetAxis("Horizontal");
    MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
Fire1 = Input.GetButton("Fire1");
     Reload = Input.GetKey(KeyCode.R);

#endif

  }

  public void SetFire(bool value)
  {
    Fire1 = value;
  }

  public void SetReload(bool value)
  {
    Reload = value;
  }
}
