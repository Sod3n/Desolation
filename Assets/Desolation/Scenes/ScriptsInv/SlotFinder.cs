using UnityEngine;

public class SlotFinder : MonoBehaviour
{
    public GameObject FindSlotWithEmptyState()
    {
        GameObject slotsObject = GameObject.Find("Slots");

        if (slotsObject != null)
        {
            foreach (Transform slotTransform in slotsObject.transform)
            {
                Debug.Log("Checking slot: " + slotTransform.name);

                foreach (Transform childTransform in slotTransform)
                {
                    Debug.Log("Checking child: " + childTransform.name);

                    if (childTransform.gameObject.name == "EmptyState" && childTransform.gameObject.activeSelf)
                    {
                        if (slotTransform.childCount < 4)
                        {
                            Debug.Log("Found active EmptyState in slot: " + slotTransform.name);
                            return slotTransform.gameObject;
                        }
                    }
                }
            }
        }

        Debug.Log("Active EmptyState slot not found.");
        return null;
    }
}