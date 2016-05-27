using UnityEngine;
using System.Collections;

public class BasicPointClick : MonoBehaviour {

    private NavMeshAgent nma;
    
	// Use this for initialization
	void Start () {
        nma = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                nma.destination = hit.point;
            }
        }
    }
}
