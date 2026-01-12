using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip goalSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Goal Reached!");
            // Additional logic for when the player reaches the goal can be added here
            audioSource.PlayOneShot(goalSound);

            LevelMenuScript.ShowMenuUI();
        }
    }
}
