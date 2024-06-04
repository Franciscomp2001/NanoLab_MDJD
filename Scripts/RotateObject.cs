using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotatingGrabInteractable : XRGrabInteractable
{
    public enum TrackedAxes
    {
        None,
        X,
        Y,
        Z
    }

    [SerializeField]
    private TrackedAxes trackedAxes = TrackedAxes.Y;

    private Vector3 originalGrabbedObjectRotation;
    private bool isRotating = false;
    private XRBaseInteractor grabbingInteractor;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        originalGrabbedObjectRotation = transform.rotation.eulerAngles;
        isRotating = false;

        grabbingInteractor = args.interactor;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        isRotating = false;
        grabbingInteractor = null;
    }

    void Update()
    {

        if (isSelected && grabbingInteractor && grabbingInteractor.selectTarget)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }

        if (isRotating)
        {

            Quaternion rotationDelta = grabbingInteractor.attachTransform.rotation * Quaternion.Inverse(grabbingInteractor.attachTransform.localRotation);

            float xRotation = trackedAxes == TrackedAxes.X ? Mathf.Atan2(rotationDelta.y, rotationDelta.w) * Mathf.Rad2Deg * 2f : 0f;
            float yRotation = trackedAxes == TrackedAxes.Y ? Mathf.Atan2(rotationDelta.x, rotationDelta.w) * Mathf.Rad2Deg * 2f : 0f;
            float zRotation = trackedAxes == TrackedAxes.Z ? Mathf.Atan2(rotationDelta.z, rotationDelta.w) * Mathf.Rad2Deg * 2f : 0f;

            transform.rotation = Quaternion.Euler(new Vector3(xRotation, yRotation, zRotation)) * Quaternion.Euler(originalGrabbedObjectRotation);
        }
    }
}
