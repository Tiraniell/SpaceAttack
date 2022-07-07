using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 5;
   
    //��������� ����� ����������� �� ��� ���������
     void PlayerControler()
    {       
        float horizonInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        GameField();
    }

    // ��������� ����� ����������� �������� �����������
    void GameField()
    {
        if (speed <= 0)
        {
            Debug.Log("Wrong value, please try again");
        }

        if (transform.position.y > 12.8f)
        {
            transform.position = new Vector3(transform.position.x, 12.8f, 0);
        }
        else if (transform.position.y < -12.8f)
        {
            transform.position = new Vector3(transform.position.x, -12.8f, 0);
        }

        if (transform.position.x > 24.8f)
        {
            transform.position = new Vector3( 24.8f, transform.position.y, 0);
        }
        else if (transform.position.x < -24.8f)
        {
            transform.position = new Vector3(-24.8f, transform.position.y, 0);
        }
    }

    void Start()
    { //������������� ������ � ��������� ����������
        transform.position = new Vector3(0, -12, 0);
    }

   
    void Update()
    {
        PlayerControler();
    }
}
