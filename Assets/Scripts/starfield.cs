using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfield : MonoBehaviour
{
    private Transform tx;
    private ParticleSystem.Particle[] points;
    public int starsmax=100;
    public float starsize = 1f;
    public float starDistance = 10;
    private float starDistanceSqr;

    ParticleSystem Particles;





    // Start is called before the first frame update
    void Start()
    {
        tx = transform;
        Particles = GetComponent<ParticleSystem>();
        starDistanceSqr = starDistance * starDistance;
    }

    private void createStars()
    {
        points = new ParticleSystem.Particle[starsmax];
        for(int i = 0; i < starsmax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].startColor = new Color(1, 1, 1, 1);
            points[i].startSize = starsize;
        }    
    }
    // Update is called once per frame
    void Update()
    {
        if (points == null)
            createStars();
        for(int inc2 = 0; inc2 < points.Length; inc2++){
            Particles.SetParticles(points, points.Length);
        }
        for(int i = 0; i < starsmax; i++)
        {
            if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            }
        }
        

         
    }
}
