using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
	Punch type;
	public bool dead;

	public void Setup(Vector3 startPos)
	{
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
				transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Jabb");
				break;
			case 1:
				print("cross");
				type = Punch.cross;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Cross");
                break;
			case 2:
				print("lhook");
				type = Punch.Lhook;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Lhook");
                break;
			case 3:
				print("luppercut");
				type = Punch.Luppercut;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Luppercut");
                break;
			case 4:
				print("rhook");
				type = Punch.Rhook;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Rhook");
                break;
			case 5:
				print("ruppercut");
				type = Punch.Ruppercut;
                transform.position = startPos;
                transform.rotation = Quaternion.identity;
                transform.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Ruppercut");
                break;
					
		}
    }

    private void FixedUpdate()
    {
		if(transform.position.z < 0)
		{
			Generate.blocksHitWrong += 1;
			Generate.consequtive = 0;
			Destroy(gameObject);
		}
		//transform.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, MainMenu.profile.speed);
		//obstacle.transform.position += new Vector3(0, 0, MainMenu.profile.speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.transform.name.Contains("Hand"))
		{
			Generate.blocksHitCorrect += 1;
			Generate.consequtive += 1;
			dead = true;
			Destroy(gameObject);
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
