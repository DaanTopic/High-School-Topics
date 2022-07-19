using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using System.Threading;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    public Text AmmoCountTextLabel;
    [SerializeField] private int num;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake() {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    int time = 0;


    public float speed;

    public Transform m_Image;
    public Transform m_Text;
    // Start is called before the first frame update

    public int targetProcess = 100;
    private float currentAmout = 0;

    private void UqdateAmmoInfo(int _ammo)
    {
        AmmoCountTextLabel.text = _ammo.ToString();
    }


    private void Update() {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)) {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if (starterAssetsInputs.aim) {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        } else {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
        }

 


        //if (starterAssetsInputs.shoot){
        if (Input.GetKeyDown(KeyCode.R))
        {
            num = 100;
            UqdateAmmoInfo(num);


        }
        if (Input.GetMouseButton(0)){
            time++;
            if (time > 5 && num > 0)
            {
                time = 0;
    
                // Hit Scan Shoot
                if (hitTransform != null) {
                    // Hit something
                    if (hitTransform.GetComponent<BulletTarget>() != null) {
                        // Hit target
                       // Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                    } else {
                        // Hit something else
                        //Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                    }
                }

                // Projectile Shoot
                UqdateAmmoInfo(num);
                num--;
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }
            if (num <= 0)
            {
                AmmoCountTextLabel.text = "Reload";
            }

        }
    }
}

