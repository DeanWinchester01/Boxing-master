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

	public void Setup(Vector3 startPos, Generate parent)
	{
		parentCode = parent;
		int punch = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Punch)).Length);
			print(punch);

		transform.position = startPos;
        transform.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -15);
        switch (punch)
		{
			case 0:
				print("jabb");
				type = Punch.Jabb;
				transform.rotation = Quaternion.identity;
				//transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Jabb");
				break;
			case 1:
				print("cross");
				type = Punch.cross;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                //transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Cross");
                break;
			case 2:
				print("lhook");
				type = Punch.Lhook;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                //transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Lhook");
                break;
			case 3:
				print("luppercut");
				type = Punch.Luppercut;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                //transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Luppercut");
                break;
			case 4:
				print("rhook");
				type = Punch.Rhook;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                //transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Rhook");
                break;
			case 5:
				print("ruppercut");
				type = Punch.Ruppercut;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                //transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Ruppercut");
                break;
					
		}
    }

    private void FixedUpdate()
    {
		if(transform.position.z < 0)
		{
			parentCode.blocksMissed += 1;
			//parentCode.blocksHitWrong += 1;
            parentCode.consequtive = 0;
			Destroy(gameObject);
		}
		//transform.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, MainMenu.profile.speed);
		//obstacle.transform.position += new Vector3(0, 0, MainMenu.profile.speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.transform.name.Contains("Hand"))
		{
            parentCode.blocksHitCorrect += 1;
            parentCode.consequtive += 1;
			dead = true;

			accuracy = Vector3.Dot(transform.forward, (collision.transform.position - transform.position).normalized);
            parentCode.accuracy += accuracy;
			Destroy(gameObject);
		}
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
