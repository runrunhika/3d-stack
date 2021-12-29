using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager instance;

    public static event Action OnCubeSpawned = delegate { };

    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;

    public Material[] sky;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        spawners = FindObjectsOfType<CubeSpawner>();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(MovingCube.CurrentCube != null)
            {
                MovingCube.CurrentCube.Stop();
            }

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            currentSpawner.SpawnCube();

            Camera.main.transform.position = MovingCube.LastCube.transform.position + new Vector3(2, 2, 1);
            Camera.main.transform.LookAt(MovingCube.LastCube.transform.position);

            OnCubeSpawned();
        }
    }

    public void ChangeSkybox(int skyIndex)
    {
        //切り替えたいタイミングでこれを書く
        RenderSettings.skybox = sky[skyIndex];
    }
}
