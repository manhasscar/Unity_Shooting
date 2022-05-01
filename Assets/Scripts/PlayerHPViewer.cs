using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();

    }

    private void Update()
    {
        //Silder UI에 현재 체력 정보를 업데이트
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
