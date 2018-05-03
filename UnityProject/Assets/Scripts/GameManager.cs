using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject PathPrefab;

    public GameObject Target;
    public GameObject PathParent;
    public GameObject Agent;

    int currentX = 40;


    bool nextLevel = false; // To be sure this only generate one path at a time


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Vector3.Distance(Target.transform.position, Agent.transform.position) < 1.42f && !nextLevel) 
        {
            StartCoroutine(NextLevel());
        }
	}

    private IEnumerator NextLevel()
    {
        nextLevel = true;
        yield return new WaitForSeconds(1f);
        
        float[] randomDirections = new float[] { 19.5f, -19.5f };
        float tmpDir = randomDirections[Random.Range(0, randomDirections.Length)];
        Debug.Log($"random dir : {tmpDir}");

        GameObject tmp = Instantiate(PathPrefab,
            new Vector3(currentX, -1, 0),
            Quaternion.identity,
            PathParent.transform);

        

        //tmp.transform.Rotate(new Vector3(0, 90, 0));

        Target.transform.position = new Vector3(currentX + 20, 0, 0);
        

        currentX += 40;

        nextLevel = false;


    }
}
