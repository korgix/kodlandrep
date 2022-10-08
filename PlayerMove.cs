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
        // moveHorizontal ����� ��������� �������� -1 ���� ������ ������ A, 1 ���� ������ D, 0 ���� ��� ������ �� ������
        float moveHorizontal = Input.GetAxis("Horizontal");
        // moveVertical ����� ��������� �������� -1 ���� ������ ������ S, 1 ���� ������ W, 0 ���� ��� ������ �� ������
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded) //��������� ��� �� ��� ����� (���� ������� ����� ������)
        {
            //����������� ���������� �����������, ��������� moveHorizontal � moveVertical
            //�� ��������� �� ����������� x � z, ���������� y ��� �������.
            direction = new Vector3(moveHorizontal, 0, moveVertical);

            //������������� ������� ��� �� �������� ������������ (���������� ��������� ���������� � ����������)
            direction = transform.TransformDirection(direction) * speed;

            if (direction.magnitude > 0)
            {
                animator.SetBool("move", true);
            }
            else animator.SetBool("move", false);

            if (Input.GetKey(KeyCode.Space)) //��������� ��� ������ ������ ��� ������
            {
                animator.SetTrigger("jump");
                direction.y = jumpForce;
            }
        }

        //���� �������� �� ������������ ��������� ��������� ������ �� ������ ������� direction
        //Time.deltaTime ��� ���������� ������ ������� ������ � ���������� �����, ��� ������������� �� �������
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