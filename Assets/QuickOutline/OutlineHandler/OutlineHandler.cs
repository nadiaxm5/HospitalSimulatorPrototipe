using System.Collections;
using UnityEngine;

// +----------------------------+
// | ---- GoragarX GameDev ---- |
// | goragarxgamedev@gmail.com  |
// +----------------------------+

[RequireComponent(typeof(Outline))]
public class OutlineHandler : MonoBehaviour
{
    /// <summary>
    /// Handles the Outline component of a given object.
    /// It uses the QuickOutline asset, developed by Chris Nolet (c) 2018
    /// </summary>

    [Header("Colors")]
    [SerializeField] private Color baseColor;
    [SerializeField] private Color highlightedColor;
    
    [Space(5)] [Header("Outline width")]
    [SerializeField] private float baseWidth = 5f;
    [SerializeField] private float highlightedWidth = 5f;
    private Outline _outline;
    private bool _locked;

    private void Awake()
    {
        //fetch component, set values
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
        _outline.OutlineColor = baseColor;
        _outline.OutlineWidth = baseWidth;
    }

    public void EnableOutline(bool b)
    {
        if (_locked) return;
        _outline.enabled = b;
    }

    /// <summary>
    /// Locks the outline enabled state to its current state (either true or false).
    /// Handy to keep the outline on while carrying an object ignoring the Mouse events
    /// </summary>
    public void LockOutline(bool b)
    {
        _locked = b;
    }

    /// <summary>
    /// Sets the outline color to the declared highlighted color for a given amount of time.
    /// If no duration is set, defaults to 0.5 seconds.
    /// </summary>
    /// <param name="seconds">highlight duration in seconds</param>
    public IEnumerator CO_Highlight(float seconds = 0.5f)
    {
        _outline.OutlineColor = highlightedColor;
        _outline.OutlineWidth = highlightedWidth;
        
        yield return new WaitForSeconds(seconds);

        _outline.OutlineColor = baseColor;
        _outline.OutlineWidth = baseWidth;
    }

    private void OnMouseEnter()
    {
        EnableOutline(true);
        _outline.OutlineColor = baseColor;
    }

    private void OnMouseExit()
    {
        EnableOutline(false);
        StopCoroutine(nameof(CO_Highlight));
        _outline.OutlineColor = baseColor;
    }
}