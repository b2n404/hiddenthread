using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject lamp;
    private bool lightOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lamp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lamp.SetActive(true); // turns on lamp supposedly 
        }
    }
}
