using UnityEngine;

public class HeartScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject); // удаляем пружину
            // GameObject.Find("Player").GetComponent<PlayerScript>().UpdateLife(50);
            other.GetComponent<PlayerScript>().UpdateLife(50);

        }
    }
}
