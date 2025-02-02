using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float velocity =1.0f;
    public float velocityRight =5.0f;
    public FixedJoystick joystick;

    private int life = 100;

    public TMP_Text healhtText;

    public int jumpForce = 4000;

    private BtnJumpScript btnJumpScript;

    Rigidbody rbPlayer;

    bool isJumping = false;


    public int money = 0;

    public TMP_Text moneyText; // ���������� ��������������� ������� �������


    public AudioClip goodSound;
    public AudioClip errorSound;
    public AudioSource audioSource;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        print("Start Life is " + life);
        btnJumpScript = GameObject.Find("BtnJump").GetComponent<BtnJumpScript>();
        rbPlayer = gameObject.GetComponent<Rigidbody>();
        moneyText.text = money.ToString();

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // print("x = " + joystick.Direction.x.ToString());
        // print("y = " + joystick.Direction.y.ToString());

        transform.position += new Vector3(
          (float)((velocity + joystick.Direction.y * velocity) * Time.deltaTime), 
          0,
          -joystick.Direction.x * velocityRight * Time.deltaTime); // ��� ���������

        //transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
        //rbPlayer.linearVelocity = transform.forward * - (joystick.Direction.x * velocity);

        Jump();
    }

    public void UpdateLife(int damage) { 
        life += damage;
        print("Current Life is " + life);
        healhtText.text = life.ToString();

        if (damage > 0)
        {
            audioSource.PlayOneShot(goodSound);
        }
        else {
            audioSource.PlayOneShot(errorSound);
        }

        if (life <= 0) {
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }

    }


    // OnCollisionEnter if isTrigger==false
    private void OnCollisionEnter(Collision collision)
    {
        // Better use tag
        // collision.gameObject.tag.Equals("Bonus")

        if (collision.gameObject.name.Equals("Bonus")) {
            Destroy(collision.gameObject);
            UpdateLife(-10);
        }
        if (collision.gameObject.name.Equals("Floor")) {
            isJumping = false;
            btnJumpScript.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpikeRotator")) {
            UpdateLife(-30);
        }
        if (other.CompareTag("Enemy")) {
            UpdateLife(-20);
        }
    }

    private void Jump() {
        print(btnJumpScript.isPressed.ToString());
        if (btnJumpScript.isPressed && !isJumping) {
            // print("������");
            /// GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            // Rigidbody rb = GetComponent<Rigidbody>();
            rbPlayer.AddForce(Vector3.up * jumpForce);
            btnJumpScript.isPressed = false;
            isJumping = true;
            btnJumpScript.gameObject.SetActive(false);
        }
        
    }

}
