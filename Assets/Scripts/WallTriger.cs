using UnityEngine;

public class WallTriger : MonoBehaviour
{
    private Animator wallAnimator;

    void Start()
    {
        wallAnimator = GameObject.Find("Enemy03").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collider " + other.gameObject.name);
        if (other.gameObject.name.Equals("Player")) {
            wallAnimator.SetBool("isWallAnimating", true);
        
        }
    }
}
