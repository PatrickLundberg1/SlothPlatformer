using UnityEngine;
using UnityEngine.UIElements;

public class PitScript : MonoBehaviour
{
    public GameObject SpawnPoint;
    private AudioSource audioSource;
    public AudioClip fallSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = SpawnPoint.transform.position;
            audioSource.PlayOneShot(fallSound);
        }
    }
}
