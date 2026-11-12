using Microsoft.AspNetCore.Components;

namespace Tellurian.WagonCardApp.Client.Components.Forms;

/// <summary>
/// Base for form sections that edit a part of the model passed in by reference.
/// Because the inputs live in this component, the parent page is not re-rendered automatically
/// when a value changes. Each input therefore calls <see cref="NotifyChangedAsync"/> so that
/// the page can refresh its live preview.
/// </summary>
public abstract class EditorSectionBase : ComponentBase
{
    [Parameter] public EventCallback OnChange { get; set; }

    protected Task NotifyChangedAsync() => OnChange.InvokeAsync();
}
