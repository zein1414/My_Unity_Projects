using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  public float x;
  public bool jump = false;
  public bool attack = false;
  public void setx(float value)
  {
    x = value;
  }
  
  public void setjump(bool value)
  {
    jump = value;
  }

  public void setAttack(bool value)
  {
    attack = true;
  }
}
