using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ListenerTest : MonoBehaviour {

    private LoopScrollRect loopScrollRect;
	// Use this for initialization
	void Awake () {
        loopScrollRect = GetComponent<LoopScrollRect>();
        loopScrollRect.AddListenerOnReturn(OnCellReturned);
        loopScrollRect.AddListenerOnData(OnCellData);
	}
	
	void OnCellReturned(Transform cell)
    {
        if (cell == null)
            return;
        Debug.Log(transform.name + ": "+ cell.name  + " is returned to pool");
    }

    void OnCellData(Transform cell,int index)
    {
        if (cell == null)
            return;
        Debug.Log(transform.name + ": " + index + " refresh data");
        //Refresh Cell Data
    }
}
