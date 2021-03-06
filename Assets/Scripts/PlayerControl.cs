using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAttack
{
    public class PlayerControl : MonoBehaviour
    {
        public GameObject laserPrefab;

        private  float fireRate = 0.3f;
        private float nextFire;

        private int playerLives = 5;

        [SerializeField] float speed = 5;

        //????????? ????? ??????????? ?? ??? ?????????
        void PlayerControler()
        {
            float horizonInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);

            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

            GameField();
        }

        // ????????? ????? ??????????? ???????? ???????????
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
                transform.position = new Vector3(24.8f, transform.position.y, 0);
            }
            else if (transform.position.x < -24.8f)
            {
                transform.position = new Vector3(-24.8f, transform.position.y, 0);
            }
        }

        void Start()
        { //????????????? ?????? ? ????????? ??????????
            transform.position = new Vector3(0, -12, 0);
        }


        void Update()
        {
            PlayerControler();
            Fire();
            
        }

        public void LifeSubstraction()
        {
            playerLives--;

            if (playerLives < 1)
            {
                Destroy(this.gameObject);
            }
        }

        

        void Fire()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > nextFire)
                {
                    Instantiate(laserPrefab, transform.position + new Vector3(0, 3f, 0), Quaternion.identity);
                    nextFire = Time.time + fireRate;
                }
               
            }

        }
    }
}