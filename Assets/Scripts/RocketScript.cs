using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketScript : MonoBehaviour {
    Rigidbody rocketRB;
    AudioSource rocketAudio;

    [SerializeField]
    float rocketThrust = 2.0f;

    [SerializeField]
    float rocketRotateVal = 0.3f;

    [SerializeField]
    AudioClip RocketSound;

    [SerializeField]
    AudioClip RocketHit;

    public int CoinsCollected;

    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rocketRB.AddRelativeForce(Vector3.up * rocketThrust);
            if (!rocketAudio.isPlaying) {
                rocketAudio.PlayOneShot(RocketSound);
            }

        }
        else {
            rocketAudio.Stop();
        }

        if (Input.GetKey(KeyCode.RightArrow)){
            rocketRB.freezeRotation = true;
            transform.Rotate(Vector3.forward * rocketRotateVal * -1);
            rocketRB.freezeRotation = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rocketRB.freezeRotation = true;
            transform.Rotate(Vector3.forward * rocketRotateVal * 1);
            rocketRB.freezeRotation = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.tag == "Respawn" ) {
            //Debug.Log("Game Over");
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentLevel);

        }

        if (collision.gameObject.tag == "Finish") {
            //Debug.Log("Level Complete");
            int newScene = SceneManager.GetActiveScene().buildIndex+1;
            SceneManager.LoadScene(newScene);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin") {
            CoinsCollected++;
            Debug.Log(CoinsCollected);
            Destroy(other.gameObject);
        }
    }

}
