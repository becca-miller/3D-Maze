using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour {
    static float timer = 0.0f;
    public Text text_box;
    public bool isRunning = false;
    Vector3 startPosition;
    public CharacterController characterController;

    // Use this for initialization
    void Start(){
        startPosition = characterController.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (isRunning) {
            timer += Time.deltaTime;
            text_box.text = timer.ToString("0.00");
        }
        if (!isRunning & Input.GetKeyDown(KeyCode.F)) {
            isRunning = true;
        }
        if (!isRunning & Input.GetKeyDown(KeyCode.P)) {
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
        characterController.transform.Rotate(0, 90, 0);
        isRunning = false;
        timer = 0.0f;
        text_box.text = "Press F to begin.";
    }

    void EndGame() {
        isRunning = false;
        text_box.text = "You win! Your time" + Environment.NewLine + 
            "was " + String.Format("{0:0.00}", timer) + " seconds." + 
            Environment.NewLine + Environment.NewLine +
            "Press escape to quit" + Environment.NewLine +
            "or P to play again.";
    }
}