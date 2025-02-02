using UnityEngine;

public class MoneyScript : MonoBehaviour
{

    private PlayerScript playerScript;
    
    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player")) {

            // 2 var.: PlayerScript playerScript = other.gameObject.GetComponent<PlayerScript>();

            playerScript.money += 1;
            playerScript.moneyText.text = playerScript.money.ToString();
            Destroy(this.gameObject);
        }
    }
}
