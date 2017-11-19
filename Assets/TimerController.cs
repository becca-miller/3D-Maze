using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Characters.FirstPerson;

public class TimerController : MonoBehaviour {
    static float timer = 0.0f;
    public Text text_box;
    public bool isRunning = false;
    public bool betweenGames = false;
    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 endPosition;
    public CharacterController characterController;

    // Use this for initialization
    void Start(){
        startPosition = characterController.gameObject.transform.position;
        startRotation = characterController.gameObject.transform.rotation;
        characterController.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (isRunning) {
            timer += Time.deltaTime;
            text_box.text = timer.ToString("0.00");
        }
        if (!isRunning & !betweenGames & Input.GetKeyDown(KeyCode.F)) {
            characterController.enabled = true;
            isRunning = true;
        }
        if (!isRunning & betweenGames & Input.GetKeyDown(KeyCode.P))
        {
            Reset();
        }
        if (Input.GetKey("escape")) {
          Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other) {
        EndGame();
    }

   void Reset() {
        characterController.gameObject.transform.position = startPosition;
        characterController.gameObject.transform.rotation = startRotation;
        isRunning = false;
        betweenGames = false;
        Time.timeScale = 1;
        timer = 0.0f;
        text_box.text = "Press F to begin.";
        characterController.enabled = false;
    }

    void EndGame() {
        isRunning = false;
        betweenGames = true;
        text_box.text = "You win! Your time" + Environment.NewLine + 
            "was " + String.Format("{0:0.00}", timer) + " seconds." + 
            Environment.NewLine + Environment.NewLine +
            "Press escape to quit" + Environment.NewLine +
            "or P to play again.";
    }
}