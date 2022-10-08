using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float gravity = 50;
    [SerializeField] float jumpForce = 30;
    [SerializeField] int crystal = 0;
    [SerializeField] Text ScoreText;
    float time = 0;
    [SerializeField] Text TimeText;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject BoomPS;
    AudioSource crystalAS;
    Animator animator;

    Vector3 direction;

    private void Start()
    {
        crystalAS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // moveHorizontal будет принимать значение -1 если нажата кнопка A, 1 если нажата D, 0 если эти кнопки не нажаты
        float moveHorizontal = Input.GetAxis("Horizontal");
        // moveVertical будет принимать значение -1 если нажата кнопка S, 1 если нажата W, 0 если эти кнопки не нажаты
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded) //провер€ем что мы неа земле (тема условий будет дальше)
        {
            //–едактируем переменную направлени€, использу€ moveHorizontal и moveVertical
            //ћы двигаемс€ по координатам x и z, координата y дл€ прыжков.
            direction = new Vector3(moveHorizontal, 0, moveVertical);

            //ƒополнительно умножа€ его на скорость передвижени€ (преобразу€ локальные координаты к глобальным)
            direction = transform.TransformDirection(direction) * speed;

            if (direction.magnitude > 0)
            {
                animator.SetBool("move", true);
            }
            else animator.SetBool("move", false);

            if (Input.GetKey(KeyCode.Space)) //ѕровер€ем что нажали пробел дл€ прыжка
            {
                animator.SetTrigger("jump");
                direction.y = jumpForce;
            }
        }

        //Ётой строчкой мы осуществл€ем изменение положени€ игрока на основе вектора direction
        //Time.deltaTime это количество секунд которое прошло с последнего кадра, дл€ синхронизации по времени
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
            speed = speed + 5; // speed += 5
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("run", false);
            speed = speed - 5; // speed -= 5
        }

        if (crystal < 10)
        {
            time += Time.deltaTime;
            int timeInt = Mathf.RoundToInt(time);
            TimeText.text = timeInt.ToString();
        }
        else
        {
            Win.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public int GetCrystal()
    {
        return crystal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            crystal += 1;
            Instantiate(BoomPS, other.transform.position, transform.rotation);
            crystalAS.Play();
            ScoreText.text = crystal.ToString();
            Destroy(other.gameObject);
        }
        if (other.tag == "BigCrystal")
        {
            crystal += 5;
            Instantiate(BoomPS, other.transform.position, transform.rotation);
            crystalAS.Play();
            ScoreText.text = crystal.ToString();
            Destroy(other.gameObject);
        }
        if (other.tag == "GameOver")
        {
            Lose.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}