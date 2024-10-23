using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCamera; // ���� ī�޶�
    [SerializeField] private List<CinemachineVirtualCamera> otherCameras; // ��Ÿ ī�޶� ����Ʈ

    private void Start()
    {
        // ���� �� ���� ī�޶� Ȱ��ȭ�ϰ� �������� ��Ȱ��ȭ
        mainCamera.gameObject.SetActive(true);
        foreach (var camera in otherCameras)
        {
            camera.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Esc Ű�� ������ �� ���� ī�޶�� ���ư���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToMainCamera();
        }
    }

    public void SwitchToCamera(int cameraIndex)
    {
        if (cameraIndex < 0 || cameraIndex >= otherCameras.Count) return;

        // ��� ī�޶� ��Ȱ��ȭ
        mainCamera.gameObject.SetActive(false);
        foreach (var camera in otherCameras)
        {
            camera.gameObject.SetActive(false);
        }

        // ������ ī�޶� Ȱ��ȭ
        otherCameras[cameraIndex].gameObject.SetActive(true);
    }

    private void SwitchToMainCamera()
    {
        // ���� ī�޶� Ȱ��ȭ
        foreach (var camera in otherCameras)
        {
            camera.gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true);
    }
}

