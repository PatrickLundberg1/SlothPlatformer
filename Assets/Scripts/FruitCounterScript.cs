using TMPro;
using UnityEngine;

public class FruitCounterScript : MonoBehaviour
{
    // There can only be one instance of FruitCounterScript
    public static FruitCounterScript Instance;
    private int fruitCount = 0;
    private int totalFruits;
    private TMP_Text counterText;
    private AudioSource audioSource;
    public AudioClip collectSound;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalFruits = GameObject.FindGameObjectsWithTag("Fruit").Length;

        counterText = GetComponent<TMP_Text>();
        counterText.text = "Fruits: 0 / " + totalFruits;
    
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UIFruitPickedUp()
    {
        Instance.fruitCount++;
        Instance.counterText.text = "Fruits: " + Instance.fruitCount + " / " + Instance.totalFruits;

        Instance.audioSource.PlayOneShot(Instance.collectSound);
    }
}
