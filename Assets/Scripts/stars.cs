
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class stars : MonoBehaviour
{
	public int MaxStars = 100;
	public float StarSize = 0.1f;
	public float StarSizeRange = 0.5f;
	public float FieldWidth = 45f;
	public float FieldHeight = 30f;
	public bool Colorize = false;
	public float Red = 1f;
	public float Green = 1f;
	public float Blue = 1f;
	public bool mainMenu;
	public Vector3 mainMenuVec = new Vector3(0,0);


	public float ParallaxFactor = 0f;

	Transform theCamera;
	[SerializeField]Rigidbody2D thePlayer = null;
	float xOffset;
	float yOffset;

	ParticleSystem Particles;
	ParticleSystem.Particle[] Stars;

	void Start()
	{
		theCamera = Camera.main.transform;
	}
	void Awake()
	{
		Stars = new ParticleSystem.Particle[MaxStars];
		Particles = GetComponent<ParticleSystem>();

		Assert.IsNotNull(Particles, "Particle system missing from object!");

		xOffset = FieldWidth * 0.5f;                                                                                                        // Offset the coordinates to distribute the spread
		yOffset = FieldHeight * 0.5f;                                                                                                       // around the object's center

		for (int i = 0; i < MaxStars; i++)
		{
			float randSize = Random.Range(StarSizeRange, StarSizeRange + 1f);                       // Randomize star size within parameters
			float scaledColor = (true == Colorize) ? randSize - StarSizeRange : 1f;         // If coloration is desired, color based on size

			Stars[i].position = GetRandomInRectangle(FieldWidth, FieldHeight) + transform.position;
			Stars[i].startSize = StarSize * randSize;
			if(Colorize == false)
			{
				Stars[i].startColor = new Color(1f, scaledColor, scaledColor, 1f);
			}
			else
			{
				Stars[i].startColor = new Color(Red, Green, Blue, 0.8f);
			}
		}
		for (int inc2 = 0; inc2 < Stars.Length; inc2++)
		{
			Particles.SetParticles(Stars, Stars.Length);                                                                // Write data to the particle system
		}
	}
	void Update()
	{
		for (int i = 0; i < MaxStars; i++)
		{

			Vector3 newPos = thePlayer.velocity * -(ParallaxFactor / 100) * Time.timeScale;                   // Calculate the position of the object
			newPos.z = 0;                       // Force Z-axis to zero, since we're in 2D
			Stars[i].position += newPos;

			Vector3 pos = Stars[i].position + transform.position;

			if (pos.x < (theCamera.position.x - xOffset))
			{
				pos.x += FieldWidth;
			}
			else if (pos.x > (theCamera.position.x + xOffset))
			{
				pos.x -= FieldWidth;
			}

			if (pos.y < (theCamera.position.y - yOffset))
			{
				pos.y += FieldHeight;
			}
			else if (pos.y > (theCamera.position.y + yOffset))
			{
				pos.y -= FieldHeight;
			}

			Stars[i].position = pos - transform.position;
		}
		for (int inc2 = 0; inc2 < Stars.Length; inc2++)
		{
			Particles.SetParticles(Stars, Stars.Length);                                                                // Write data to the particle system
		}
		if (mainMenu)
		{
			for (int i = 0; i < MaxStars; i++)
			{

				Vector3 newPos = mainMenuVec * -(ParallaxFactor / 100) * Time.timeScale;                   // Calculate the position of the object
				newPos.z = 0;                       // Force Z-axis to zero, since we're in 2D
				Stars[i].position += newPos;

				Vector3 pos = Stars[i].position + transform.position;

				if (pos.x < (theCamera.position.x - xOffset))
				{
					pos.x += FieldWidth;
				}
				else if (pos.x > (theCamera.position.x + xOffset))
				{
					pos.x -= FieldWidth;
				}

				if (pos.y < (theCamera.position.y - yOffset))
				{
					pos.y += FieldHeight;
				}
				else if (pos.y > (theCamera.position.y + yOffset))
				{
					pos.y -= FieldHeight;
				}

				Stars[i].position = pos - transform.position;
			}
			for (int inc2 = 0; inc2 < Stars.Length; inc2++)
			{
				Particles.SetParticles(Stars, Stars.Length);                                                                // Write data to the particle system
			}
		}

	}
	// GetRandomInRectangle
	//----------------------------------------------------------
	// Get a random value within a certain rectangle area
	//
	Vector3 GetRandomInRectangle(float width, float height)
	{
		float x = Random.Range(0, width);
		float y = Random.Range(0, height);
		return new Vector3(x - xOffset, y - yOffset, 10);
	}
}
