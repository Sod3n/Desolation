using HierarchicalStatePattern;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    private GameObject _slot;
    private void Add(GameObject item, GameObject slot)
    {

        if (item == null)
        {
            Debug.LogError("Попытка добавить пустой объект.");
            return;
        }

        if (slot == null)
        {
            Debug.LogError("Не удалось найти слот для добавления объекта.");
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
                Debug.Log("Объект добавлен в слот.");
            }
        }
        else return;
    }

    [ContextMenu("Add Item")]
    public void AddItem(string itemName)
    {
        // Получаем компонент SlotFinder из другого объекта
        SlotFinder slotFinder = FindObjectOfType<SlotFinder>();

        if (slotFinder != null)
        {
            // Ищем слот с объектом EmptyState
            GameObject emptyStateSlot = slotFinder.FindSlotWithEmptyState();

            if (emptyStateSlot != null)
            {
                Debug.Log("Найден слот с объектом EmptyState: " + emptyStateSlot.name);
                _slot = emptyStateSlot; // Сохраняем найденный слот
            }

            // Поиск всех объектов с компонентом ItemInfoProvider
            ItemInfoProvider[] itemProviders = FindObjectsOfType<ItemInfoProvider>();

            foreach (ItemInfoProvider provider in itemProviders)
            {
                if (!provider.itemInfo.slotted && provider.gameObject.name == itemName)
                {
                    Debug.Log("Item " + itemName + " is not slotted.");

                    // Если слот найден, добавляем предмет в слот
                    if (_slot != null)
                    {
                        // Получаем GameObject из ItemInfoProvider
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
            // Проверяем, содержит ли слот объект предмета
            if (slot.childCount > 3)
            {
                // Перебираем всех потомков слота
                for (int i = 0; i < slot.childCount; i++)
                {
                    // Получаем объект предмета, находящийся в этом слоте
                    GameObject itemObject = slot.GetChild(i).gameObject;

                    // Получаем компонент ItemInfoProvider объекта предмета
                    ItemInfoProvider itemInfoProvider = itemObject.GetComponent<ItemInfoProvider>();

                    // Проверяем наличие компонента ItemInfoProvider
                    if (itemInfoProvider != null)
                    {
                        itemObject.transform.SetParent(null);
                        itemObject.GetComponent<ItemInfoProvider>().itemInfo.slotted = false;
                        Debug.Log("Объект с компонентом ItemInfoProvider удален из слота " + slot.name);
                        return;
                    }
                }

                // Если объект с компонентом ItemInfoProvider не найден в слоте
                Debug.Log("Объект с компонентом ItemInfoProvider не найден в слоте " + slot.name);
            }
            else
            {
                Debug.Log("В слоте " + slot.name + " нет объекта предмета.");
            }
        }
        else
        {
            Debug.Log("Слот для удаления предмета не указан.");
        }
    }



}
