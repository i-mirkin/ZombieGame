using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public string wallToOpen = "WallFirst";
    
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
            Destroy(gameObject); // удаляем объект коллизии
            // GameObject.Find("Player").GetComponent<PlayerScript>().UpdateLife(50);
            // other.GetComponent<PlayerScript>().velocity *= 1.5f;
            GameObject.Find(wallToOpen).GetComponent<Animator>().SetBool("open", true);



        }
    }

}
