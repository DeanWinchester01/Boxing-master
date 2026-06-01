using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable enable
public class Obstacle : MonoBehaviour
{
	public bool dead;
	float accuracy;
	public Generate? parentCode;
	public Map? secondParentCode;
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

	public void SetParent(Map parent) => secondParentCode = parent;

	public void SetParent(Generate parent) => parentCode = parent;

	public void Setup(Vector3 startPos, Punch type)
	{
		transform.position = startPos;
		//body.rotation

        switch (type)
		{
			case Punch.Jabb:
				if (MainMenu.profile.hand) // force right hand for now
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
				if (MainMenu.profile.hand) //force right hand for now
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
				transform.position = startPos + leftJabb;
                transform.rotation = Quaternion.Euler(0, 180+45,0);
                ColorBlock(Color.blue);
                break;
			case Punch.Luppercut:
                transform.position = startPos + topLeft;
                transform.rotation = Quaternion.Euler(45,180+0,0);
                ColorBlock(Color.blue);
                break;
			case Punch.Rhook:
                transform.position = startPos + rightJabb;
                transform.rotation = Quaternion.Euler(0,180-45,0);
                ColorBlock(Color.green);
                break;
			case Punch.Ruppercut:
                transform.position = startPos + topRight;
                transform.rotation = Quaternion.Euler(45,180 + 0,0);
                ColorBlock(Color.green);
                break;
					
		}
    }

	public void Remove()
	{
        transform.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -MainMenu.profile.speed*5);

        if (transform.position.z < 0)
        {
			if (parentCode)
			{
				parentCode.blocksMissed += 1;
				parentCode.consequtive = 0;
			}
			else
			{
				secondParentCode.blocksMissed += 1;
				secondParentCode.consequtive = 0;
			}
				Destroy(gameObject);
        }
    }


	public void Hit(Collision collision)
	{
        if (collision.transform.name.Contains("Glove"))
        {
            HandTracker tracker = collision.transform.GetComponent<HandTracker>();
            float speed = tracker.speed;

            accuracy = Vector3.Dot(transform.forward, (collision.transform.position - transform.position).normalized);
			if (parentCode) {
				parentCode.blocksHitCorrect += 1;
				parentCode.consequtive += 1;
				parentCode.accuracy += accuracy;
			}
			else
			{
				secondParentCode.blocksHitCorrect += 1;
				secondParentCode.consequtive += 1;
				secondParentCode.accuracy += accuracy;
			}
				dead = true;

            Destroy(gameObject);
        }
        if (collision.transform.name == "Head")
        {
			if(parentCode)
				parentCode.consequtive = 0;

			if (secondParentCode)
				secondParentCode.consequtive = 0;
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
