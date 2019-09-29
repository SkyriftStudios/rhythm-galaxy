using UnityEngine;
using RhythmGalaxyHelper;

public class LvlShootingStarScript : MonoBehaviour
{
    public static GameObject[] objects = new GameObject[100];
    public static bool[] tasksDone = new bool[100];
    public static void Start() // Ensures all objects in objects are null.
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i] = null;
    }
    public static void Update()
    {
        if (TimeCheck.IsTaskNotDone(1f, tasksDone[0]))
        {
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            tasksDone[0] = true;
        }
        if (TimeCheck.IsTaskNotDone(5f, tasksDone[1]))
        {
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            objects[55] = Rocket.Create(Vector2.zero);
            tasksDone[1] = true;
        }
        if (TimeCheck.IsTaskNotDone(7f, tasksDone[2]))
        {
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            objects[55].GetComponent<Rocket>().BlastOff();
            tasksDone[2] = true;
        }
        if (TimeCheck.IsTaskNotDone(10f, tasksDone[3]))
        {
            Ship.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)), Resources.Load("Prefabs/ship") as GameObject, 3);
            tasksDone[3] = true;
        }
        if (TimeCheck.IsTaskNotDone(11f, tasksDone[4]))
        {
            Ship.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)), Resources.Load("Prefabs/ship") as GameObject, 3);
            Ship.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)), Resources.Load("Prefabs/ship") as GameObject, 3);
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            tasksDone[4] = true;
        }
        if (TimeCheck.IsTaskNotDone(12f, tasksDone[5]))
        {
            Ship.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)), Resources.Load("Prefabs/ship") as GameObject, 3);
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            ShootingStar.Create(new Vector2(10, UnityEngine.Random.Range(-5, 5)));
            tasksDone[5] = true;
        }
    }
}
