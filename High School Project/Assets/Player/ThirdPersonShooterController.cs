using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Animations.Rigging;
using Inventory;
using Inventory.Model;

public class ThirdPersonShooterController : MonoBehaviour
{
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
    public Rig idleRig, aimRig;
    [SerializeField] public int num;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs _input;
    private Animator animator;
    public AudioClip LandingAudioClip;
    [Range(0, 5)] public float GunAudioVolume = 0.5f;
    public ItemSO ItemSO;

    private void Awake()
    {
        //  aimVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        _input = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    int time = 0;


    public float speed;

    public Transform m_Image;
    public Transform m_Text;
    // Start is called before the first frame update

    public int targetProcess = 100;
    //private float currentAmout = 0;


    //
    private float shakeTimer;
    private float startingIntensity;
    private float shakeTimerTotal;


    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            aimVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimer = time;
        shakeTimerTotal = time;

    }
    private void UqdateAmmoInfo(int _ammo)
    {
        AmmoCountTextLabel.text = _ammo.ToString();
    }


    private float countrecoil = 0;
    private int recoildelay = 2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InventoryController inventoryController = GetComponent<InventoryController>();
            inventoryController.BuildUse(ItemSO, 1);
            Debug.Log("USE R");    
        }
        //
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                aimVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, shakeTimer / shakeTimerTotal);
        }

        //


        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if (_input.aim)
        {
            idleRig.weight = 0;
            aimRig.weight = 1;
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 13f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else if(!animator.GetBool(Animator.StringToHash("Jump")))
        {
            idleRig.weight = 1;
            aimRig.weight = 0;
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
        }


        if (num <= 0)
        {
            AmmoCountTextLabel.text = "Reload";
        }
        else
        {
            UqdateAmmoInfo(num);
        }


        //if (starterAssetsInputs.shoot){
        if (Input.GetMouseButton(0) && _input.aim)
        {
            time++;
            if (time > 5 && num > 0)
            {
                time = 0;

                // Hit Scan Shoot
                if (hitTransform != null)
                {
                    // Hit something
                    if (hitTransform.GetComponent<BulletTarget>() != null)
                    {
                        // Hit target
                        // Instantiate(vfxHitGreen, mouseWorldPosition, Quaternion.identity);
                    }
                    else
                    {
                        // Hit something else
                        //Instantiate(vfxHitRed, mouseWorldPosition, Quaternion.identity);
                    }
                }
                // Projectile Shoot
                UqdateAmmoInfo(num);
                num--;
                Quaternion quaternion = aimVirtualCamera.m_LookAt.transform.rotation;
                Vector3 vector3 = aimVirtualCamera.m_LookAt.transform.position;

                vector3.y += 0.03f;
                countrecoil += 0.03f;
                aimVirtualCamera.m_LookAt.SetPositionAndRotation(vector3, quaternion);



                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                _input.shoot = false;
                ShakeCamera(1f, .1f);

                AudioSource.PlayClipAtPoint(LandingAudioClip, spawnBulletPosition.transform.position, GunAudioVolume);
            }

        }
        else
        {
            recoildelay++;
            if (recoildelay > 10)
            {
                recoildelay = 0;
                if (countrecoil > 0)
                {
                    Quaternion quaternion = aimVirtualCamera.m_LookAt.transform.rotation;
                    Vector3 vector3 = aimVirtualCamera.m_LookAt.transform.position;
                    //vector3.y += 0.05f;

                    vector3.y -= 0.05f;
                    countrecoil -= 0.05f;
                    aimVirtualCamera.m_LookAt.SetPositionAndRotation(vector3, quaternion);
                }
            }
        }
    }
}

