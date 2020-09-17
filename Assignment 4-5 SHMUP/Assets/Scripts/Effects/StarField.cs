using UnityEngine;
using UnityEngine.Assertions;
 
public class StarField : MonoBehaviour
{
	public int maxStars = 100;
	public float starSize = 0.1f;
	public float starSizeRange = 0.5f;
	public float fieldWidth = 20f;
	public float fieldHeight = 25f;
	public bool colorize = false;
	float xOffset;
	float yOffset;
	ParticleSystem Particles;
	ParticleSystem.Particle[] Stars;
	void Awake()
	{
		Stars = new ParticleSystem.Particle[maxStars];
		Particles = GetComponent<ParticleSystem>();
		Assert.IsNotNull(Particles, "Particle system missing from object!");
		xOffset = fieldWidth * 0.5f; // Offset the coordinates to distribute the spread
		yOffset = fieldHeight * 0.5f; // around the object's center
		for (int i = 0; i < maxStars; i++)
		{
			float randSize = Random.Range(starSizeRange, starSizeRange + 1f); // Randomize star size within parameters
			float scaledColor = (true == colorize) ? randSize - starSizeRange : 1f; // If coloration is desired, color based on size
			Stars[i].position = GetRandomInRectangle(fieldWidth, fieldHeight) + transform.position;
			Stars[i].startSize = starSize * randSize;
			Stars[i].startColor = new Color(1f, scaledColor, scaledColor, 1f);
		}
		Particles.SetParticles(Stars, Stars.Length);// Write data to the particle system
	}
	// GetRandomInRectangle
	//----------------------------------------------------------
	// Get a random value within a certain rectangle area
	//
	Vector3 GetRandomInRectangle(float width, float height)
	{
		float x = Random.Range(0, width);
		float y = Random.Range(0, height);
		return new Vector3(x - xOffset, y - yOffset, 0);
	}
}
