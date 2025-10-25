using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Pathoschild.Stardew.Common;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace Pascalcula.Stardew.AutomaticDining.Framework;

/// <summary>The raw mod configuration.</summary>
internal class ModConfig
{
    /*********
    ** Accessors
    *********/
    /// <summary>The keys which toggle Automatic Eating/Drinking.</summary>
    public KeybindList ToggleAutomaticEating { get; set; } = new(SButton.E);
    public KeybindList ToggleAutomaticDrinking { get; set; } = new(SButton.R);

    /*********
    ** Public methods
    *********/
    /// <summary>Normalize the model after it's deserialized.</summary>
    /// <param name="context">The deserialization context.</param>
    [OnDeserialized]
   // [SuppressMessage("ReSharper", "NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract", Justification = SuppressReasons.MethodValidatesNullability)]
  //  [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaOnDeserialized)]
    public void OnDeserialized(StreamingContext context)
    {
        this.ToggleAutomaticEating ??= new KeybindList();
        this.ToggleAutomaticDrinking ??= new KeybindList();
    }
}
