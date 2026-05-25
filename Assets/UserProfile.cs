using NUnit.Framework;
using System.Collections.Generic;

public class UserProfile
{
    public float speed, random, volume;
    public bool hand;

    public List<int> levelsComplete;

    public UserProfile()
    {
        speed = 1;
        random = 1;
        volume = .5f;
        hand = true;
        levelsComplete = new List<int>();
    }
}
