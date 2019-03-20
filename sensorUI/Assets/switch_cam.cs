using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_cam : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject img;
    public GameObject eye;
    public GameObject top;
    public GameObject vis_prompt;
    public GameObject ceiling;
    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(true);
        cam1.tag = "MainCamera";
        Cursor.lockState = CursorLockMode.None;
        img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (cam1.gameObject.activeSelf == true) //transition to perspective view
            {
                GameMaster.Instance.player.transform.position = new Vector3(Camera.main.transform.position.x, -0, Camera.main.transform.position.z);
                Vector3 travelVel = GameMaster.Instance.player.GetComponent<Rigidbody>().velocity;
                //Limiting velocity to still seem cool but not fall off the map
                GameMaster.Instance.player.GetComponent<Rigidbody>().velocity= new Vector3(Mathf.Clamp(travelVel.x,0,100), Mathf.Clamp(travelVel.y, 0, 100), Mathf.Clamp(travelVel.z, 0, 100));

                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                img.SetActive(true);
                eye.SetActive(true);
                top.SetActive(false);
                ceiling.SetActive(true);
                vis_prompt.SetActive(true);
            }
            else if (cam2.gameObject.activeSelf == true)
            {
                //Change the camera to be where the person was
                Vector3 playerPos = GameMaster.Instance.player.transform.position;
                cam1.gameObject.transform.position = new Vector3(playerPos.x, cam1.gameObject.transform.position.y, playerPos.z);

                cam2.gameObject.SetActive(false);
                cam1.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                img.SetActive(false);
                eye.SetActive(false);
                top.SetActive(true);
                ceiling.SetActive(false);
                vis_prompt.SetActive(false);
            }
        }
    }
}
