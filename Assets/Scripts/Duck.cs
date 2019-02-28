using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour {

    public GameObject explosionPrefab;
    public int idColor; // 0 white. 1 other

    GameObject explosion;
    bool exploding = false;
    Color32[] colors;

    public void Start()
    {
        if (idColor == 0)
        {
            colors = new Color32[] {
                new Color32(72, 129, 55, 255),
                new Color32(227, 190, 58, 255),
                new Color32(90, 64, 54, 255),
                new Color32(199, 108, 43, 255),
                new Color32(78, 72, 70, 255),
                new Color32(67, 45, 39, 255)
            };
        }
        else
        {
            colors = new Color32[] {
                new Color32(230, 230, 230, 255),
                new Color32(200, 200, 200, 255),
                new Color32(210, 210, 210, 255),
                new Color32(199, 136, 43, 255),
                new Color32(227, 190, 58, 255),
                new Color32(0, 0, 0, 255)
            };
        }

        
    }

    public void Explode()
    {
        explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f));
        exploding = true;
    }

    private void LateUpdate()
    {
        if (exploding)
        {
            ParticleSystem explosionParticleSystem = explosion.GetComponent<ParticleSystem>();
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[explosionParticleSystem.main.maxParticles];

            int numParticlesAlive = explosionParticleSystem.GetParticles(particles);
            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].startColor = colors[Random.Range(0, colors.Length)];
            }
            explosionParticleSystem.SetParticles(particles, numParticlesAlive);
            exploding = false;

            Destroy(gameObject);
        }
    }
 
}
