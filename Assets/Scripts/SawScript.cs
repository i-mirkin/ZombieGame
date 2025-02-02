using UnityEngine;

public class SawScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            other.GetComponent<PlayerScript>().UpdateLife(-20);

        }
    }
}
