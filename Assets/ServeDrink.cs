using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class ServeDrink : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isServed = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (GameFlow.bowlValue == 0)
            {
                this.transform.position = new Vector3(0, 1f, -2.5f);
                GameFlow.bowlValue += 1;
                Debug.Log("karamono_bowl moved." + GameFlow.bowlValue);
            } else if (GameFlow.bowlValue > 0)
        {
            if (GameFlow.orderValue == GameFlow.bowlValue)
            {
                isServed = true;
                Debug.Log("Match! Drink has been served.");
            }
            else
                Debug.Log("Unmatch! drink has been served.");
        }

    }
}
