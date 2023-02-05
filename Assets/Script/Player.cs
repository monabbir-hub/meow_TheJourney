using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public float moveSpeed = 5.0f;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    public Rigidbody2D rb;
    public Animator anim;    

    Vector2 movement;

     void Update()
    {
        if (dialogueUI.IsOpen) return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        


        if(movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            anim.SetFloat("LastX", movement.x);
            anim.SetFloat("LastY", movement.y);
        }


        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
                Interactable.Interact(this);
        }

        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }



}
