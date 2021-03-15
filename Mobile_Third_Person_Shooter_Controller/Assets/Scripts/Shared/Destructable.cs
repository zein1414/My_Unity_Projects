using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
  [SerializeField] private float hitPoints;

  public event System.Action OnDeath;
  public event System.Action OnDamageReceived;

  private float damagetakan;

  public float HitPointsRemaining
  {
    get
    {
      return hitPoints - damagetakan;
    }
  }

  public bool IsAlive
  {
    get
    {
      return HitPointsRemaining > 0;
    }
  }

  public virtual void Die()
  {
    if(IsAlive)return;
    if (OnDeath != null) OnDeath();
  }

  public virtual void TakeDamge(float value)
  {
    damagetakan += value;
    if (OnDamageReceived != null)
      OnDamageReceived();
    if(HitPointsRemaining<=0)
      Die();
  }

  public void Reset()
  {
    damagetakan = 0;
  }
}
