using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetecter : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        //"MainCamera" �±׸� ������ �ִ� ������Ʈ Ž�� �� Camera ������Ʈ ���� ����
        // GameObject.FindGameObjectWithTag("MainCamera").GetComponenet<Camera>(); �� ����
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            // ray.origin : ������ ������ġ(= ī�޶� ��ġ)
            // ray.direction : ������ ����
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //2D ����͸� ���� 3D������ ������Ʈ�� ���콺�� �����ϴ� ���
            // ������ �ε����� ������Ʈ�� �����ؼ� hit�� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Tile"))
                {
                    towerSpawner.SpawnTower(hit.transform);
                }
            }
        }
    }
}
