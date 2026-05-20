using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    private Vector3 spawnPosition;
    private GameObject player;

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
        if (player != null)
        {
            player.transform.position = spawnPosition;
        }
        
    }
}
