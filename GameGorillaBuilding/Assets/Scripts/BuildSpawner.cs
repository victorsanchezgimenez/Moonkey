using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{
    [Header("List of Prefabs Builds")]
    public List<GameObject> builds; 

    private float offSet = 40f;
    
    //Order list of builds
    void Start()
    {
        if(builds != null && builds.Count > 0)
        {
            builds = builds.OrderBy(r => r.transform.position.y).ToList();
        }
    }

    //Move the build
    public void MoveBuild()
    {
        GameObject moveBuild = builds[0];
        builds.Remove(moveBuild);
        float newY = builds[builds.Count - 1].transform.position.y + offSet;
        moveBuild.transform.position = new Vector3(0, newY, 0);
        builds.Add(moveBuild);
    }
}
