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

        [SerializeField]
        private GameObject playerExplosionPrefab;

        [SerializeField]
        private int playerLives = 3;

        [SerializeField] 
        float speed = 5;

        [SerializeField]
        private AudioSource laserShot;

        //Реализуем метод перемещения по оси координат
        void PlayerControler()
        {
            float horizonInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);

            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

            GameField();
        }

        // Реализуем метод ограничения игрового простанства
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
        { //Устанавливаем обьект в начальные координаты
            transform.position = new Vector3(0, -12, 0);

            laserShot = GetComponent<AudioSource>();
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
                Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        

        void Fire()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > nextFire)
                {
                    laserShot.Play();
                    Instantiate(laserPrefab, transform.position + new Vector3(0, 3f, 0), Quaternion.identity);
                    nextFire = Time.time + fireRate;
                }
               
            }

        }
    }
}