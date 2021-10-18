using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float RangeRadius;
    [Range(0,360)]
    public float FOVAngle;
    public LayerMask ItemMask;
    public LayerMask WallMask;
    public Vector3 directionToItem;
    public GameObject ItemInView;
    public Transform ItemTransform;
    public Interactables ActiveItem;
    public Stack<Interactables> ItemStack;
    public Stack<GameObject> ItemUI;
    public RectTransform UsabeItemUITransform;
    public RectTransform ItemUITransform;

    private void Start()
    {
        ItemStack = new Stack<Interactables>();
    }

    private void Update()
    {
        FieldOfViewCheck();

        if(ItemInView != null)
        {
            if(ItemInView.tag == "HealthPickup")
            {
                ActiveItem = new HealthPickup();
            }

            if(ItemInView.tag == "StaminaPickup")
            {
                ActiveItem = new StaminaPickup();
            }

            if(ItemInView.tag == "JournalPage")
            {
                ActiveItem = new JournalPage();
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                ActiveItem.Action(this);
                Destroy(ItemInView);
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && ItemStack.Count != 0)
        {
            ItemStack.Pop().Use(this);
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] CollidersInRange = Physics.OverlapSphere(transform.position, RangeRadius, ItemMask);

        if (CollidersInRange.Length != 0)
        {
            ItemTransform = CollidersInRange[0].transform;

            directionToItem = (ItemTransform.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToItem) < FOVAngle / 2)
            {
                float distanceToItem = Vector3.Distance(transform.position, ItemTransform.position);

                if (!Physics.Raycast(transform.position, directionToItem, distanceToItem, WallMask))
                {
                    ItemInView = CollidersInRange[0].gameObject;
                }
            }
        }
    }
}
