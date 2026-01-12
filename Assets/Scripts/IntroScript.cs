using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private bool hasStarted = false;

    public InputActionAsset inputActions;
    private InputAction clickAction;

    private void OnEnable()
    {
        inputActions.FindActionMap("UI").Enable();
        Debug.Log("UI controls enabled.");
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("UI").Disable();
        Debug.Log("UI controls disabled.");
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        Debug.Log("IntroScript Awake called.");
        var uiActionMap = inputActions.FindActionMap("UI");
        // Getting actions from the project-wide Input System

        clickAction = uiActionMap.FindAction("Click");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (clickAction.WasReleasedThisFrame())
        {
            Debug.Log("Intro skipped via click.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }
    }

    void FixedUpdate()
    {
        // Set to auto play the video on start in the component settings, no need to call Play() here
        if (videoPlayer.isPlaying && !hasStarted)
        {
            hasStarted = true;
        }

        // Move to the next scene when the video finishes
        if (hasStarted && !videoPlayer.isPlaying)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }
    }
}
