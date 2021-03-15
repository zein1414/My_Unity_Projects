using UnityEngine;

public class Burger : MonoBehaviour
{
    public float rotationSpeed = 50;
    public GameObject eating;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.numberOfCoins += 1;
            Instantiate(eating);
            Destroy(gameObject);
        }
    }
}
