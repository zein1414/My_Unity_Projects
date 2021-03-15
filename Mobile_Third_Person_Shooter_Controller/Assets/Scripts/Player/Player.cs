using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    [SerializeField] private float speed;

    [SerializeField] private MouseInput MouseControl;

    private MoveController moveController;
    
    private InputController playerInput;

    private Vector2 mouseInput;

    private Crosshair _crosshair;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        moveController = GetComponent<MoveController>();
        GameManager.Instance.Player = this;
        _crosshair = GetComponentInChildren<Crosshair>();
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 direction=new Vector2(playerInput.Vertical*speed,playerInput.Horizontal*speed);
      moveController.Move(direction);

      mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
      mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
      
      transform.Rotate(Vector3.up*mouseInput.x*MouseControl.Sensitivity.x);
      _crosshair.LookHeight(mouseInput.y*MouseControl.Sensitivity.y);
    }
}
