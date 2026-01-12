using UnityEngine;
using UnityEngine.UIElements;

public class LevelMenuScript : MonoBehaviour
{
    // Can only be one instance of LevelMenuScript
    public static LevelMenuScript instance;

    private UIDocument uiDocument;
    private Label levelCompleteLabel;
    private Button mainMenuButton;

    private void Awake()
    {
        instance = this;

        uiDocument = GetComponent<UIDocument>();

        var root = uiDocument.rootVisualElement;
        levelCompleteLabel = root.Q<Label>("LevelCompleteText");
        mainMenuButton = root.Q<Button>("MainMenuButton");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShowMenuUI()
    {
        instance.levelCompleteLabel.style.display = DisplayStyle.Flex;

        instance.mainMenuButton.style.display = DisplayStyle.Flex;
        instance.mainMenuButton.RegisterCallback<ClickEvent>(ev =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        });
    }

    private void OnDestroy()
    {
        instance.mainMenuButton.UnregisterCallback<ClickEvent>(ev => { });
        instance = null;
    }
}
