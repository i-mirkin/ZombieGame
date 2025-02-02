using System.Collections;
using UnityEngine;

public class SawStartsScript : MonoBehaviour
{

    public GameObject saw1;
    public GameObject saw2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SawStarts());
    }

    private IEnumerator SawStarts() {
        saw1.GetComponent<Animator>().SetBool("start", true);
        yield return new WaitForSeconds(1);
        saw2.GetComponent<Animator>().SetBool("start", true);
        yield return new WaitForSeconds(1);
    }

    
}
