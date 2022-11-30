using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
   public bool _isStoneExist;
  [SerializeField] public GameObject stone;
    public GameObject _stoneClone;
  [SerializeField] public Transform stoneSpawnPoint;

    private void Start()
    {
        _isStoneExist = false;
    }
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.X)&&!_isStoneExist)
        {  
            _isStoneExist = true;
            _stoneClone =Instantiate(stone, stoneSpawnPoint);
            
        } else
        {
            if (Input.GetKeyDown(KeyCode.X) && _isStoneExist)
            { 
                Destroy(_stoneClone);
                _stoneClone = Instantiate(stone, stoneSpawnPoint);
                _isStoneExist = true;

            }
            

        }
       


    }
}
