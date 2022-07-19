using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingProcess : MonoBehaviour
{
    public float speed;

    public Transform m_Image;
    public Transform m_Text;
    // Start is called before the first frame update

    public int targetProcess = 100;
    private float currentAmout = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmout < targetProcess)
        {
            currentAmout += speed;
            if (currentAmout > targetProcess)
                currentAmout = targetProcess;
            m_Text.GetComponent<Text>().text = ((int)currentAmout).ToString();
            m_Image.GetComponent<Image>().fillAmount = currentAmout / 100.0f;
        }
    }
}
