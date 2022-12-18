using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseCk : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public void onMouseEnter()
    {
        text.color = new Color(0.5f, 0.5f, 0.5f);
    }
    public void onMouseExit()
    {
        text.color = new Color(255, 255, 255);
    }
}
