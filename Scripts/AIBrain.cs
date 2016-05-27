using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIBrain : MonoBehaviour {

    
    public float thinkTime = 1.0f;
    public bool aiDebugGui = false;

    [SerializeField]
    public List<AIThoughtScriptable> thoughts;
    
    private ThoughData thoughtData;
    private List<ThoughData> thoughList;
    private float nextActionTime = 0.0f;
    
    void Start () {
        thoughList = new List<ThoughData>();
    }
	
	void Update () {
        // Restict thougths to a 1 second tick.
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + thinkTime;
            ProcessThoughts();
        }
    }

    public void ProcessThoughts()
    {
        if (thoughts == null) { return; }
        float lastThought = Mathf.Infinity;
        float currentThought = 0;
        int strongestUrge = 0;
        bool haveThought = false;

        thoughList.Clear();

        // Check every though in our list
        
        for (int i = 0; i < thoughts.Count; i++)
        {
            haveThought = true;
            ThoughData thoughtData = new ThoughData();
            currentThought = Mathf.Clamp(thoughts[i].ReturnWeight(gameObject), 0, 100);

            // Draw debug gui if needed.
            if (aiDebugGui)
            {
                thoughtData.urge = currentThought;
                thoughtData.thought = thoughts[i].typeOfThought;
                thoughList.Add(thoughtData);
            }

            // Work out which is the most urgent thought by finding the smallest.
            if (currentThought < lastThought)
            {
                lastThought = currentThought;
                strongestUrge = i;
            }

        }

        if (haveThought)
        {
            // Execute the throught script by passing its owner to it.
            thoughts[strongestUrge].OnExecuteThought(gameObject);
        }
    }

    public void OnGUI()
    {
        if (aiDebugGui)
        {
            float width = 500;
            for (int i = 0; i < thoughList.Count; i++)
            {
                ThoughData thought = thoughList[i];
                float widthper = thought.urge / 100;

                GUI.Box(new Rect(10, (30 * i) + 10, widthper * width, 30), thought.thought);
            }
        }
    }

    public class ThoughData
    {
        public float urge;
        public string thought;
    }
}
