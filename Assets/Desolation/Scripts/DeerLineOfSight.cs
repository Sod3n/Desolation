using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DeerLineOfSight : MonoBehaviour
{
    [System.Serializable]
    public class TargetVisibility
    {
        public GameObject target;
        public bool isVisible;
    }

    [SerializeField] private List<TargetVisibility> targets = new List<TargetVisibility>();
    [SerializeField] private List<GameObject> visibleTargets = new List<GameObject>();
    [SerializeField] private float detectionDelay = 0f;
    private Coroutine detectPlayerCoroutine;
    private SphereCollider detectionCollider;
    private bool hasVisibleTarget = false;
    private int visibleTargetsBeforeRemoval = 0;
    private GameObject lastTarget; 

    public bool isLastVisibleTarget = false;
    private bool isVisibleLastTarget;

    private void Awake()
    {
        detectionCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var targetVisibility = targets.Find(t => t.target == other.gameObject);
            if (targetVisibility == null)
            {
                targetVisibility = new TargetVisibility { target = other.gameObject };
                targets.Add(targetVisibility);
                if (IsPlayerVisible(other.gameObject))
                {
                    hasVisibleTarget = true;
                    InputDeer.InvokeOnTargetAppear();
                }
            }

            detectPlayerCoroutine = StartCoroutine(DetectPlayer(targetVisibility));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var targetVisibility = targets.Find(t => t.target == other.gameObject);
            if (targetVisibility != null)
            {
                // Проверяем, является ли удаляемая цель первой в списке видимых целей
                if (visibleTargets.Count > 0 && visibleTargets[0] == other.gameObject)
                {
                    // Вызываем InputDeer.InvokeOnTargetChange() только если удаляется первая цель
                    InputDeer.InvokeOnTargetChange();
                }

                StopCoroutine(detectPlayerCoroutine);
                targets.Remove(targetVisibility);
            }
        }
    }


    IEnumerator DetectPlayer(TargetVisibility targetVisibility)
    {
        while (true)
        {
            yield return new WaitForSeconds(detectionDelay);

            bool isVisible = IsPlayerVisible(targetVisibility.target);

            if (isVisible)
            {
                targetVisibility.isVisible = true;
                isVisibleLastTarget = true;
                if (!hasVisibleTarget)
                {
                    hasVisibleTarget = true;
                    InputDeer.InvokeOnTargetAppear();
                }
            }
            else
            {
                targetVisibility.isVisible = false;
                isVisibleLastTarget = false;
            }
        }
    }

    private bool wasAnyTargetVisible = false;

    private void Update()
    {
        bool isAnyTargetVisible = false;

        foreach (var targetVisibility in targets)
        {
            if (targetVisibility.isVisible)
            {
                isAnyTargetVisible = true;
                break;
            }
        }

        if ((!isAnyTargetVisible && wasAnyTargetVisible) || (wasAnyTargetVisible && targets.Count == 0))
        {
            InputDeer.InvokeOnTargetLost();
        }

        wasAnyTargetVisible = isAnyTargetVisible;

        visibleTargets.Clear();

        foreach (var targetVisibility in targets)
        {
            if (targetVisibility.isVisible)
            {
                visibleTargets.Add(targetVisibility.target);
            }
        }

        // Сохраняем количество видимых целей до следующего обновления
        int previousVisibleCount = visibleTargets.Count;

        // Вызываем метод OnTargetChange() только если удаляется первая цель
        if (previousVisibleCount > 0 && previousVisibleCount > visibleTargets.Count)
        {
            InputDeer.InvokeOnTargetChange();
        }
    }


    private void OnTargetChange()
    {
        if (visibleTargets.Count > 1)
        {
            if (lastTarget != visibleTargets[0])
            {
                lastTarget = visibleTargets[0];
                InputDeer.InvokeOnTargetChange();
            }
        }
    }

    private bool IsPlayerVisible(GameObject player)
    {
        Vector3 direction = player.transform.position - transform.position;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, detectionCollider.radius);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Cover"))
            {
                float distance = Vector3.Distance(transform.position, hit.point);
                float playerDistance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < playerDistance)
                {
                    return false;
                }
                Debug.DrawRay(transform.position, (transform.position - hit.point), Color.red, 10f);
            }
        }
        return true;
    }
}
