using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject m_Prefab;
    public KeyCode m_KeyCode;
    [SerializeField] private float ypos = 0.1f;

    void Update()
    {
        if (Input.GetKeyDown(m_KeyCode) && m_Prefab != null){
            var position = new Vector3(Random.Range(-5.0f, 5.0f), ypos, Random.Range(-5.0f, 5.0f));
            Instantiate(m_Prefab, position, Quaternion.identity);
        }
    }
}
