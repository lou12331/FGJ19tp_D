using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransferToAnother : MonoBehaviour
{
    public bool test = true;
    public GameObject[] cubeBlock = new GameObject[4];

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ZoomInEffect();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ZoomOutEffect();
        }
    }

    public void ZoomInEffect()
    {
        Vector3 bottom = new Vector3(0, -14.5f, 0);
        Vector3 upper = new Vector3(0, 14f, 0);
        Vector3 left = new Vector3(-14, 0, 0);
        Vector3 right = new Vector3(14, 0, 0);

        //for (int i = 0; i < 1; i++)
        //{
        //    cubeBlock[0].transform.localPosition = Vector3.Lerp(cubeBlock[0].transform.localPosition, bottom, 0.1f);
        //    cubeBlock[1].transform.localPosition = Vector3.Lerp(cubeBlock[1].transform.localPosition, upper, 0.1f);
        //    cubeBlock[2].transform.localPosition = Vector3.Lerp(cubeBlock[2].transform.localPosition, left, 0.1f);
        //    cubeBlock[3].transform.localPosition = Vector3.Lerp(cubeBlock[3].transform.localPosition, right, 0.1f);
        //}
        cubeBlock[0].transform.DOLocalMove(bottom, 0.5f, true).SetEase(Ease.OutCubic);
        cubeBlock[1].transform.DOLocalMove(upper, 0.5f, true).SetEase(Ease.OutCubic);
        cubeBlock[2].transform.DOLocalMove(left, 0.5f, true).SetEase(Ease.OutCubic);
        cubeBlock[3].transform.DOLocalMove(right, 0.5f, true).SetEase(Ease.OutCubic);
    }

    public void ZoomOutEffect()
    {
        Vector3 bottom = new Vector3(0, -28, 0);
        Vector3 upper = new Vector3(0, 28, 0);
        Vector3 left = new Vector3(-10000, 0, 0);
        Vector3 right = new Vector3(10000, 0, 0);

        //cubeBlock[0].transform.localPosition = Vector3.Lerp(cubeBlock[0].transform.localPosition, bottom, 0.01f);
        //cubeBlock[1].transform.localPosition = Vector3.Lerp(cubeBlock[1].transform.localPosition, upper, 0.01f);
        //cubeBlock[2].transform.localPosition = Vector3.Lerp(cubeBlock[2].transform.localPosition, left, 0.000015f);
        //cubeBlock[3].transform.localPosition = Vector3.Lerp(cubeBlock[3].transform.localPosition, right, 0.000015f);

        cubeBlock[0].transform.DOLocalMove(bottom, 0.3f, true).SetEase(Ease.OutCubic);
        cubeBlock[1].transform.DOLocalMove(upper, 0.3f, true).SetEase(Ease.OutCubic);
        cubeBlock[2].transform.DOLocalMove(left, 0.3f, true).SetEase(Ease.OutCubic);
        cubeBlock[3].transform.DOLocalMove(right, 0.3f, true).SetEase(Ease.OutCubic);

    }
}
