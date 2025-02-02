using System;
using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    private Vector2 startTouchPosition, endTouchPosition;
    private Touch touch;
    private IEnumerator goCoroutine;
    private bool coroutineAllowed;

    private Vector2 startMousePosition, endMousePosition;


    private BtnJumpScript btnJumpScript;

    public float speed = 5f;      // Скорость движения
    public float jumpForce = 5f;  // Сила прыжка
    private bool moveRight = false;
    private bool moveLeft = false;

    private Vector2 lastTouchPosition;
    private float touchStartTime;
    private float clickThreshold = 0.2f;

    private Rigidbody rb;
    private bool isGrounded = true; // Проверка на земле

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coroutineAllowed = true;
        //GameObject.Find("Canvas").SetActive(false);
        // rb = GameObject.Find("Player").GetComponent<Rigidbody>(); // Получаем Rigidbody
        rb = GetComponent<Rigidbody>(); // Получаем Rigidbody
        btnJumpScript = GameObject.Find("BtnJump").GetComponent<BtnJumpScript>();

    }

    // Update is called once per frame
    void Update()
    {


        HandleMouseInput();  // Управление мышью
        HandleTouchInput();  // Управление сенсорным экраном

        // Двигаем объект в нужную сторону
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (moveLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }




        // 0:left-click
        // 1:right-click
        // 2:middle-click
        // свайп вправо/влево - движение на несколько позиций влево/вправо
        //if (Input.GetMouseButtonDown(0)) {
        //    startMousePosition = Input.mousePosition;
        //    Debug.Log("start: " + startMousePosition.x + " " + startMousePosition.y);
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    endMousePosition = Input.mousePosition;
        //    Debug.Log("end: " + endMousePosition.x + " " + endMousePosition.y);

        //    // from right to left
        //    if ((endMousePosition.x - startMousePosition.x) >= 100) {
        //        goCoroutine = Go(new Vector3(0.25f, 0, 0));
        //        StartCoroutine(goCoroutine);
        //    }
        //    if ((endMousePosition.x - startMousePosition.x) <= -100)
        //    {
        //        goCoroutine = Go(new Vector3(-0.25f, 0, 0));
        //        StartCoroutine(goCoroutine);
        //    }
        //}


        // https://www.youtube.com/watch?v=thAB9LTSyEk&ab_channel=AlexanderZotov
        //if (Input.touchCount > 0) { 
        //    touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        startTouchPosition = touch.position;
        //    }

        //    if (touch.phase == TouchPhase.Ended && coroutineAllowed)
        //    {
        //        endTouchPosition = touch.position;

        //        if ((endTouchPosition.y > startTouchPosition.y) && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
        //        {
        //            goCoroutine = Go(new Vector3(0, 0, 0.25f));
        //            StartCoroutine(goCoroutine);
        //        }
        //        else if ((endTouchPosition.y < startTouchPosition.y) && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
        //        {
        //            goCoroutine = Go(new Vector3(0, 0, -0.25f));
        //            StartCoroutine(goCoroutine);
        //        }
        //        else if ((endTouchPosition.x < startTouchPosition.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
        //        {
        //            goCoroutine = Go(new Vector3(-0.25f, 0, 0));
        //            StartCoroutine(goCoroutine);
        //        }
        //        else if ((endTouchPosition.x > startTouchPosition.x) && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
        //        {
        //            goCoroutine = Go(new Vector3(0.25f, 0, 0));
        //            StartCoroutine(goCoroutine);
        //        }
        //    }

        //}



    }


    // position x - left/right y - up/down z - back/forward
    private IEnumerator Go(Vector3 position) { 
        coroutineAllowed = false;
        for (int i = 0; i <= 2; i++) {
            transform.Translate(position);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i <= 2; i++)
        {
            transform.Translate(position);
            yield return new WaitForSeconds(0.01f);
        }
        transform.Translate(position);
        coroutineAllowed |= true;
    }


    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPosition = Input.mousePosition;
            touchStartTime = Time.time;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = (Vector2)Input.mousePosition - lastTouchPosition;

            if (mouseDelta.x > 5f)
            {
                moveRight = true;
                moveLeft = false;
            }
            else if (mouseDelta.x < -5f)
            {
                moveLeft = true;
                moveRight = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            float clickDuration = Time.time - touchStartTime;

            if (clickDuration <= clickThreshold)
            {
                Jump();
            }

            moveRight = false;
            moveLeft = false;
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
                touchStartTime = Time.time;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.position - lastTouchPosition;

                if (touchDelta.x > 5f)
                {
                    moveRight = true;
                    moveLeft = false;
                }
                else if (touchDelta.x < -5f)
                {
                    moveLeft = true;
                    moveRight = false;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                float touchDuration = Time.time - touchStartTime;

                if (touchDuration <= clickThreshold)
                {
                    Jump();
                }

                moveRight = false;
                moveLeft = false;
            }
        }
    }


    private void Jump()
    {

        btnJumpScript.isPressed = true;

        //if (Mathf.Abs(rb.velocity.y) < 0.01f) // Проверка, на земле ли объект
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}
    }


}
