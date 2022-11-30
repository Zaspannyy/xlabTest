using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsChange : MonoBehaviour
{
   [SerializeField] MeshFilter[] items;
   [SerializeField] Mesh[] itemsToChange;
 
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            for (int i=0; i< items.Length; i++)
            {
                items[i].mesh = itemsToChange[Random.Range(0, itemsToChange.Length)];
            }
            }
    }
}
