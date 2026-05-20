using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    private Vector3 spawnPosition;
    private GameObject player;

    public AudioClip enemySound;
    public ParticleSystem enemyParticles;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPosition = player.transform.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetPosition();
    }

    void ResetPosition()
    {
        //instanciar sonido
        if (enemySound != null)
        {
            GameObject audioObject = new GameObject("PointEffectSound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = enemySound;
            audioSource.Play();
            Destroy(audioObject, enemySound.length);
        }

        //instanciar partículas
        if (enemyParticles != null)
        {
            ParticleSystem particles = Instantiate(enemyParticles, transform.position, Quaternion.identity);
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration);
        }

        if (player != null)
        {
            player.transform.position = spawnPosition;
        }
        
    }
}
