using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceAttack {

    public class EnemyController : MonoBehaviour
    {
        private int speed = 7;

        [SerializeField]
        private GameObject enemyExposionPrefab;

        [SerializeField]
        private AudioClip explosionSound;


        void EnemySpeed()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        void EnemySpawnPoint()
        {
            if (transform.position.y < -18f)
            {
                transform.position = new Vector3(Random.Range(-25.5f, 25.5f), 18f, 0);
            }
        }
     

        void Update()
        {
            EnemySpeed();
            EnemySpawnPoint();
        }

         private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Laser")
            {
                Destroy(collision.gameObject);
                Instantiate(enemyExposionPrefab, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
                Destroy(this.gameObject);

            }

            else if (collision.tag == "Player")
            {
                PlayerControl playerControl = collision.GetComponent<PlayerControl>();

                if(playerControl != null)
                {
                    playerControl.LifeSubstraction();
                }
                Instantiate(enemyExposionPrefab, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
                Destroy(this.gameObject);
            }
        }

    }
}