using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
	Punch type;
	public bool dead;
	float accuracy;
	Generate parentCode;
	[Space(10)]
	public Vector3 leftJabb;
	public Vector3 rightJabb;
	public Vector3 topLeft;
	public Vector3 topRight;
	public Vector3 bottomLeft;
	public Vector3 bottomRight;
	public Vector3 leftSmash;
	public Vector3 rightSmash;


	public void ColorBlock(Color color)
	{
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		for(int i = 0; i < renderer.materials.Length; i++)
		{
			renderer.materials[i].color = color;
		}
	}

	public void Setup(Vector3 startPos, Punch type)
	{

		transform.position = startPos;
		//body.rotation

        switch (type)
		{
			case Punch.Jabb:
				print("jabb");
				if (MainMenu.profile.hand)
				{
					//right hand as main
					ColorBlock(Color.blue);
					transform.position = startPos + leftJabb;
				}
				else
				{
					//left hand as main
					ColorBlock(Color.green);
					transform.position = startPos + rightJabb;
				}
					break;
			case Punch.Cross:
				print("cross");
				if (MainMenu.profile.hand)
				{
					transform.position = startPos + rightSmash;
					ColorBlock(Color.green);
				}
				else
				{
					transform.position = startPos + leftSmash;
					ColorBlock(Color.green);
				}
					break;
			case Punch.Lhook:
				print("lhook");
				transform.position = startPos + leftJabb;
                transform.rotation = Quaternion.Euler(0, 180+45,0);
                ColorBlock(Color.blue);
                //transform.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
			case Punch.Luppercut:
				print("luppercut");
                transform.position = startPos + topLeft;
                transform.rotation = Quaternion.Euler(45,180+0,0);
                ColorBlock(Color.blue);
                //transform.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
			case Punch.Rhook:
				print("rhook");
                transform.position = startPos + rightJabb;
                transform.rotation = Quaternion.Euler(0,180-45,0);
                ColorBlock(Color.green);
                //transform.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
			case Punch.Ruppercut:
				print("ruppercut");
                transform.position = startPos + topRight;
                transform.rotation = Quaternion.Euler(45,180 + 0,0);
                ColorBlock(Color.green);
                //transform.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
					
		}
    }

	public void Remove()
	{
        transform.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -MainMenu.profile.speed);

        if (transform.position.z < 0)
        {
            parentCode.blocksMissed += 1;
            //parentCode.blocksHitWrong += 1;
            parentCode.consequtive = 0;
            Destroy(gameObject);
        }
        //transform.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, MainMenu.profile.speed);
        //obstacle.transform.position += new Vector3(0, 0, MainMenu.profile.speed * Time.fixedDeltaTime);
    }


	public void Hit(Collision collision)
	{
        if (collision.transform.name.Contains("Glove"))
        {
            HandTracker tracker = collision.transform.GetComponent<HandTracker>();
            float speed = tracker.speed;

            parentCode.blocksHitCorrect += 1;
            parentCode.consequtive += 1;
            dead = true;

            accuracy = Vector3.Dot(transform.forward, (collision.transform.position - transform.position).normalized);
            parentCode.accuracy += accuracy;
            Destroy(gameObject);
        }
        if (collision.transform.name == "Head")
        {
            parentCode.consequtive = 0;
            Destroy(gameObject);
        }
    }

	private void FixedUpdate() => Remove();
    private void OnCollisionEnter(Collision collision) => Hit(collision);

	public enum Punch
	{
        Jabb,
		Cross, 
		Lhook, 
		Rhook, 
		Luppercut,
		Ruppercut
	}
}
