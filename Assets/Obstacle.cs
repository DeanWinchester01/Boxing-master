using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
	Punch type;
	GameObject obstacle;
	List<GameObject> obstacles;
	GameObject container;
	public bool dead;

	public Obstacle(Punch punch)
	{
		type = punch;

		if(punch == Punch.Jabb)
		{
			obstacle = Instantiate(obstacles[0]);
		}
		obstacle.transform.parent = container.transform;
		obstacle.AddComponent<Obstacle>();
	}

    private void FixedUpdate()
    {
		obstacle.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, MainMenu.profile.speed);
		//obstacle.transform.position += new Vector3(0, 0, MainMenu.profile.speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.transform.name.Contains("Hand"))
		{
			dead = true;
			Destroy(obstacle);
		}
    }

    void Kill()
	{

	}

    public enum Type
	{
		TopLeft,
		MiddleLeft,
		BottomLeft,
		TopRight,
		MiddleRight,
		BottomRight,
		Center,
		LeftBlock,
		RightBlock,
		CenterBlock
	}
	public enum Punch
	{
        Jabb, 
		cross, 
		Lhook, 
		Rhook, 
		Luppercut,
		Ruppercut
	}
}
