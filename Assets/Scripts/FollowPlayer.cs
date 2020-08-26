using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 30f;
    //public bool canMove = false;
    public bool canMove = false;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Camera.main.transform.eulerAngles.x;
        
        Quaternion rotMin = Quaternion.Euler(new Vector3(-20f, 0, 0));
        Quaternion rotMax = Quaternion.Euler(new Vector3(20f, 0, 0));
        //Quaternion rotation = transform.rotation;
        Quaternion rotation = Camera.main.transform.rotation;

 
        if(!canMove){
            if(rotation.x <= rotMin.x){            
                canMove = true;
                Debug.Log("Go");
            }
        }
         
        if(canMove){
            if(rotation.x >= rotMax.x){
                canMove = false;
                Debug.Log("Stop");
            }
        }

        if(canMove){
            //this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Vector3 cameraAngle = Camera.main.transform.forward;
            this.gameObject.transform.Translate(cameraAngle * Time.deltaTime * speed);
            Debug.Log("Walking"); 
        }
       
        // if(Input.GetButtonDown("Fire1")){
        //     canMove = !canMove;
        // }

       
    }

// OnCollisionEnter() -> sto ce se dogoditi nakon "sudara" OnCollisionStay i OnCollisionExit
    private void OnCollisionEnter(Collision otherObject) 
    {
        if(otherObject.transform.tag == "stopper"){
            canMove = false;  
        } 

        Debug.Log("Collision detected: " +  otherObject.gameObject.name);
        
    }
}
