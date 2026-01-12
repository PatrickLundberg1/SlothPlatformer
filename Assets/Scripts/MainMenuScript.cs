using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private UIDocument uiDocument;

    private float lastBackButtonPressTime = 0f;
    private const float backButtonPressThreshold = 2f; // Time to confirm exit

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        var startButton = root.Q<Button>("StartButton");
        startButton.clicked += OnStartButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Stage1");
    }

    private void ShowToastMessage(string message)
    {
        Debug.Log("Toast Message: " + message);

        // Create and show a toast message on Android
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if(currentActivity != null)
        {
            AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", context, message, toastClass.GetStatic<int>("LENGTH_SHORT"));
                toastObject.Call("show");
            }));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            float currentTime = Time.time;
            if (currentTime - lastBackButtonPressTime < backButtonPressThreshold)
            {
                Application.Quit();
            }
            else
            {
                ShowToastMessage("Press back again to exit");
                lastBackButtonPressTime = currentTime;
            }
        }
    }
}
