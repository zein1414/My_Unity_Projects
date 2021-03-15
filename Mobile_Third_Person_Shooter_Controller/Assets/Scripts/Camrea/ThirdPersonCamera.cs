using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float damping;

    //gameobject transform attached to the player
    private Transform cameraLookTarget;
    //the player
    private Player Player;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.OnStartPlayer += HandleOnStart;
    }

    //setting the player
    void HandleOnStart(Player player)
    {
        Player = player;
        cameraLookTarget = Player.transform.Find("cameraLookTarget");
    }
    // Update is called once per frame
    void Update()
    {
        //calculating the camera position to lerp to it
        Vector3 targetPostion = cameraLookTarget.position + Player.transform.forward * cameraOffset.z +
                                Player.transform.up * cameraOffset.y +
                                Player.transform.right * cameraOffset.x;
        
        transform.position=Vector3.Lerp(transform.position,targetPostion,damping*Time.deltaTime);
        
        //calculating the target rotation to lerp to it
        Quaternion targetRotation=Quaternion.LookRotation(cameraLookTarget.position-targetPostion,Vector3.up);
        
        transform.rotation=Quaternion.Lerp(transform.rotation,targetRotation,damping*Time.deltaTime);
    }
}
