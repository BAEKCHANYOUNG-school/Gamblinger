using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainCamera; // 메인 카메라
    [SerializeField] private List<CinemachineVirtualCamera> otherCameras; // 기타 카메라 리스트

    private void Start()
    {
        // 시작 시 메인 카메라만 활성화하고 나머지는 비활성화
        mainCamera.gameObject.SetActive(true);
        foreach (var camera in otherCameras)
        {
            camera.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Esc 키를 눌렀을 때 메인 카메라로 돌아가기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToMainCamera();
        }
    }

    public void SwitchToCamera(int cameraIndex)
    {
        if (cameraIndex < 0 || cameraIndex >= otherCameras.Count) return;

        // 모든 카메라 비활성화
        mainCamera.gameObject.SetActive(false);
        foreach (var camera in otherCameras)
        {
            camera.gameObject.SetActive(false);
        }

        // 선택한 카메라 활성화
        otherCameras[cameraIndex].gameObject.SetActive(true);
    }

    private void SwitchToMainCamera()
    {
        // 메인 카메라 활성화
        foreach (var camera in otherCameras)
        {
            camera.gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true);
    }
}

