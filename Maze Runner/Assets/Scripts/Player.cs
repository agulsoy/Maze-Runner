using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public CameraTrigger trig;
    public float speed = 1.0f;
    private CharacterController _characterController;
    //public Collider collider;
    public Inventory2 inventory;
    Vector3 facing_direction = new Vector3(0.0f, 0.0f, 1.0f);
    // string save_path;
    // Start is called before the first frame update
    void Start()
    {
        // this.save_path = Application.persistentDataPath + "/save.json";

        // if(System.IO.File.Exists(save_path)){
        //     var serialized = System.IO.File.ReadAllText(this.save_path);
        //     var save_game = JsonUtility.FromJson<SaveGame>(serialized);
        //     this.GetComponent<Transform>().position = save_game.player_pos;

        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        var character_controller = this.GetComponent<CharacterController>();
        var direction = new Vector3(

            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
            ).normalized;
        
            var delta = direction * this.speed;
            character_controller.SimpleMove(delta);

            facing_direction = Vector3.Lerp(direction, this.facing_direction, 0.96f);
            var transform = this.GetComponent<Transform>();
            var target = transform.position + facing_direction;
            transform.LookAt(target);
    		
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

    // public void Save(){
    //     SaveGame save = new SaveGame();
    //     save.player_pos = this.GetComponent<Transform>().position;
    //     string serialized = JsonUtility.ToJson(save, true);

    //     using (var file = new System.IO.StreamWriter(save_path)){
    //         file.Write(serialized);    
    //     }
    //     Debug.Log("Autosave to " + save_path);
    // }
}