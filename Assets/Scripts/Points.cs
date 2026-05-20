using UnityEngine;

public class Points : MonoBehaviour
{

    public AudioClip pointSound;
    public ParticleSystem pointParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePoint();
    }

    void RotatePoint()
    {
        transform.Rotate(new Vector3(15, 45, 30) * Time.deltaTime);
    }

    public void GetPoints()
    {
        //instanciar sonido
        if (pointSound != null)
        {            
            GameObject audioObject = new GameObject("PointEffectSound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = pointSound;
            audioSource.Play();
            Destroy(audioObject, pointSound.length);
        }

        //instanciar partículas
        if (pointParticles != null)
        {
            ParticleSystem particles = Instantiate(pointParticles, transform.position, Quaternion.identity);
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration);
        }


        GameManager.instance.AddPoint(1);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
