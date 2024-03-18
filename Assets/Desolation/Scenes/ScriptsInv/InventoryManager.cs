using HierarchicalStatePattern;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    private GameObject _slot;
    private void Add(GameObject item, GameObject slot)
    {

        if (item == null)
        {
            Debug.LogError("������� �������� ������ ������.");
            return;
        }

        if (slot == null)
        {
            Debug.LogError("�� ������� ����� ���� ��� ���������� �������.");
            return;
        }
        if (!item.gameObject.GetComponent<ItemInfoProvider>().itemInfo.slotted)
        {
            if (_slot.transform.childCount > 3)
            {
                return;
            }
            else
            {

                item.transform.SetParent(slot.transform, false);
                item.GetComponent<ItemInfoProvider>().itemInfo.slotted = true;
                Debug.Log("������ �������� � ����.");
            }
        }
        else return;
    }

    [ContextMenu("Add Item")]
    public void AddItem(string itemName)
    {
        // �������� ��������� SlotFinder �� ������� �������
        SlotFinder slotFinder = FindObjectOfType<SlotFinder>();

        if (slotFinder != null)
        {
            // ���� ���� � �������� EmptyState
            GameObject emptyStateSlot = slotFinder.FindSlotWithEmptyState();

            if (emptyStateSlot != null)
            {
                Debug.Log("������ ���� � �������� EmptyState: " + emptyStateSlot.name);
                _slot = emptyStateSlot; // ��������� ��������� ����
            }

            // ����� ���� �������� � ����������� ItemInfoProvider
            ItemInfoProvider[] itemProviders = FindObjectsOfType<ItemInfoProvider>();

            foreach (ItemInfoProvider provider in itemProviders)
            {
                if (!provider.itemInfo.slotted && provider.gameObject.name == itemName)
                {
                    Debug.Log("Item " + itemName + " is not slotted.");

                    // ���� ���� ������, ��������� ������� � ����
                    if (_slot != null)
                    {
                        // �������� GameObject �� ItemInfoProvider
                        GameObject itemObject = provider.gameObject;
                        Add(itemObject, _slot);
                    }
                }
                else
                {
                    Debug.Log("Item " + itemName + " is slotted or not found.");
                }
            }
        }
    }

    [ContextMenu("Remove")]
    public void Remove(Transform slot)
    {
        if (slot != null)
        {
            // ���������, �������� �� ���� ������ ��������
            if (slot.childCount > 3)
            {
                // ���������� ���� �������� �����
                for (int i = 0; i < slot.childCount; i++)
                {
                    // �������� ������ ��������, ����������� � ���� �����
                    GameObject itemObject = slot.GetChild(i).gameObject;

                    // �������� ��������� ItemInfoProvider ������� ��������
                    ItemInfoProvider itemInfoProvider = itemObject.GetComponent<ItemInfoProvider>();

                    // ��������� ������� ���������� ItemInfoProvider
                    if (itemInfoProvider != null)
                    {
                        itemObject.transform.SetParent(null);
                        itemObject.GetComponent<ItemInfoProvider>().itemInfo.slotted = false;
                        Debug.Log("������ � ����������� ItemInfoProvider ������ �� ����� " + slot.name);
                        return;
                    }
                }

                // ���� ������ � ����������� ItemInfoProvider �� ������ � �����
                Debug.Log("������ � ����������� ItemInfoProvider �� ������ � ����� " + slot.name);
            }
            else
            {
                Debug.Log("� ����� " + slot.name + " ��� ������� ��������.");
            }
        }
        else
        {
            Debug.Log("���� ��� �������� �������� �� ������.");
        }
    }



}
