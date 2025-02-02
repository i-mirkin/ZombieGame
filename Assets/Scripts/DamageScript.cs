using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damage = 5;
    
    private void OnCollisionEnter(Collision collision)
    {
        PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
        playerScript.UpdateLife(damage);

    }
}
