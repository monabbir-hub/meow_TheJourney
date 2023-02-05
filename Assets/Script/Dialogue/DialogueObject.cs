using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [TextArea] public string[] dialogue;

    public string[] Dialogue => dialogue;

    
}
