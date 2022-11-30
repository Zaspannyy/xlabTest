using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloudLogic : MonoBehaviour
{
    [SerializeField] public Vector3 startPos;
    [SerializeField] public Vector3 currentPos;
    [SerializeField] public Vector3 endPos;
    [SerializeField] public Transform[] positions;
    [SerializeField] public float speed;
    [SerializeField] public float progress;
    [SerializeField] int i;
    [SerializeField] bool isMoving;
    [SerializeField] ParticleSystem rain;
    [SerializeField] ParticleSystem lightening;
    [SerializeField] Animator anim;
   
    private void Start()
    {
        isMoving = false;
        endPos = positions[0].position;
        transform.position = positions[0].position;
    }

    private void Update()
    {
        MovementLogic();
        ProgressCut();

        if (Input.GetKeyDown(KeyCode.Z)&&!isMoving)
        {
            LapStep();
        }
    }

    public void LapStep()
    {
        isMoving = true;
        progress = 0;
        i++;

        if (i == positions.Length)
        {
            i = 0;
        }

        startPos = endPos;
        endPos = positions[i].position;   
    }

    public void MovementLogic()
    {
        if (isMoving)
        {
            anim.SetBool("isMoving", true);
            StopRain();
            transform.position = Vector3.Lerp(startPos, endPos, progress);
            progress += speed * Time.deltaTime;
        }

        else
        {
            anim.SetBool("isMoving", false);
            anim.SetTrigger("startRain");
        }
    }
    public void StartRain()
    {
        lightening.maxParticles = 1;
        rain.maxParticles = 10000;
       
    }
    public void StopRain()
    {
        rain.maxParticles = 0;
        lightening.maxParticles = 0;
    }
    public void ProgressCut()
    {
        if (progress >= 1)
        {
            progress = 1;
            isMoving = false;
        }
    }
    
}
