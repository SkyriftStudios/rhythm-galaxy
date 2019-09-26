using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmGalaxyHelper;

public class LvlOneScript : MonoBehaviour
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
        if (TimeCheck.IsItTime(1, objects[0]))
        {
            objects[0] = Bullet.Create(new Vector2(10, 0), Vector2.left * 4f, 0f);
        }
        if (TimeCheck.IsItTime(5, objects[2]))
        {
            objects[2] = BulletSpread.Create(new Vector2(5, 0), 8, cooldown: 0.2f, translate: true, isParent: true);
            objects[2].GetComponent<Rigidbody2D>().velocity = Vector2.left * 0.1f;
            objects[2].GetComponent<BulletSpread>().bulletSpeed = 7f;
        }

        // Bullet spread rotation
        if (objects[2] != null)
            objects[2].transform.eulerAngles += new Vector3(0, 0, 30f * Time.deltaTime);

        // Three time attack and destroy
        if (TimeCheck.IsItTime(30))
            objects[2].GetComponent<BulletSpread>().Attack();

        if (TimeCheck.IsItTime(30.1f))
            objects[2].GetComponent<BulletSpread>().Attack();

        if (TimeCheck.IsItTime(30.2f))
            objects[2].GetComponent<BulletSpread>().Attack();

        if (TimeCheck.FullTimeCheck(30.3f, tasksDone[2]))
        {
            tasksDone[2] = true;
            objects[3] = Instantiate(LevelManager.emptyObj, Vector3.zero, Quaternion.identity) as GameObject;
            ExtraTranslations.RelocateChildrenFromTo(objects[2], objects[3]);

            // objects[2].transform.DetachChildren();
            Destroy(objects[2]);
        }

        if (TimeCheck.FullTimeCheck(45f, tasksDone[3]))
        {
            tasksDone[3] = true;
            Destroy(objects[3]);
        }
    }
}
