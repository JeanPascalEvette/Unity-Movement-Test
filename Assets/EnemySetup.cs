using UnityEngine;
using System.Collections;
using RAIN.Action;
using RAIN.Core;

public class EnemySetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var memory = GetComponent<RAIN.Core.AIRig>().AI.WorkingMemory;
        memory.SetItem<float>("startY", GetComponent<Transform>().position.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
