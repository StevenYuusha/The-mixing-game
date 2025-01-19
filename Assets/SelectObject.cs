using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public GameObject targetObj;
    public int ingredientValue;
    public bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        /*
        // select bowl
        if (gameObject.name == "karamono_bowl")
        {
            Debug.Log("user clicked karamono_bowl.");


            if (GameFlow.bowlValue == 0)
            {
                targetObj.transform.position = new Vector3(0, 1f, -2.5f);
                GameFlow.bowlValue += ingredientValue;
                Debug.Log("karamono_bowl moved." + GameFlow.bowlValue);
            }
        }
        */

        if (gameObject.name == "sake_bottle")
        {
            if (GameFlow.bowlValue > 0)
            {
                if (!isSelected)
                {
                    targetObj.transform.position = new Vector3(5f, 6f, -2f);
                    targetObj.transform.Rotate(0, 0, 30f);
                    isSelected = true;
                    Debug.Log("sake_bottle is selected." + GameFlow.bowlValue);
                }
                else if (isSelected)
                {
                    targetObj.transform.position = new Vector3(10f, 5f, 6f);
                    targetObj.transform.rotation = Quaternion.Euler(0, 0, 0);
                    isSelected = false;
                    Debug.Log("sake_bottle has been de-selected." + GameFlow.bowlValue);
                }

            }
            else
                Debug.Log("karamono_bowl has NOT been init." + GameFlow.bowlValue);
        }
    }
}
