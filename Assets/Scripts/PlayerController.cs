using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    [SerializeField] PlayerMotor playerMotor;

    CharacterAttribute characterAttribute;
    CharacterAnimator characterAnimator;
    Rigidbody rigid;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIPlayManager.instance.isOpenUI && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 300, movementMask))
                {
                    //Debug.Log("Hit point " + hit.point);
                    playerMotor.MoveToPoint(hit.point);
                }
                if (hit.collider.tag == "NPC")
                {
                    if (checkDistanceNPC(transform.position, hit.transform.position) < 4f)
                    {
                        UIPlayManager.instance.ShowDialog(characterAttribute.type, QuestManager.instance.currentQuest);
                    }
                }
            }

            characterAnimator.PlayAnimWalk(playerMotor.currentSpeed());
        }
    }

    public void SetComponentCharacter(CharacterAnimator animator, CharacterAttribute attribute)
    {
        characterAnimator = animator;
        characterAttribute = attribute;
    }

    float checkDistanceNPC(Vector3 player, Vector3 npc)
    {
       return Vector3.Distance(player, npc);
    }

    public void MoveToMoveToReceivePlace(Vector3 place)
    {
        playerMotor.MoveToPoint(place);
    }
}
