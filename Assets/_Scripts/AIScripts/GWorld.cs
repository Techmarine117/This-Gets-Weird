using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceQueue
{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t, string ms, WorldStates w)
    {

        tag = t;
        modState = ms;
        if (tag != "")
        {
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject r in resources)
                que.Enqueue(r);
        }
        if (modState != "")
        {
            w.ModifyState(modState, que.Count);
        }

    }

    public void AddResource(GameObject r)
    {
        que.Enqueue(r);
    }

    public GameObject RemoveResource()
    {
        if (que.Count == 0) return null;
        return que.Dequeue();
    }


}

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static ResourceQueue Waypoint;
    private static Dictionary<string, ResourceQueue> ressources = new Dictionary<string, ResourceQueue>();


    static GWorld()
    {
        world = new WorldStates();
       Waypoint = new ResourceQueue("Waypoint","FreeWaypoint", world);
        ressources.Add("Waypoint", Waypoint);



        Time.timeScale = 5;
    }

    public ResourceQueue GetQueue(string type)
    {
        return ressources[type];
    }

    private GWorld()
    {

    }


    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}