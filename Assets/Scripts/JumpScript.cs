using UnityEngine;

public class JumpScript : MonoBehaviour
{

    private GameObject btnJump;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnJump = GameObject.Find("BtnJump");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player")) {
            btnJump.SetActive(true); // активируем кнопку 
            Destroy(gameObject); // удаляем пружину
        }
    }
}
