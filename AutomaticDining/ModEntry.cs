using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Pathoschild.Stardew.Common;
using Pathoschild.Stardew.Common.Integrations.GenericModConfigMenu;
using Pathoschild.Stardew.Common.Integrations.IconicFramework;
using Pascalcula.Stardew.AutomaticDining.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Characters;
using SObject = StardewValley.Object;

namespace Pascalcula.Stardew.AutomaticDining;

/// <summary>The mod entry point.</summary>
internal class ModEntry : Mod
{
    /*********
    ** Fields
    *********/

    // TODO FIXME
    /// <summary>The unique item ID for a horse flute.</summary>
//    private const string HorseFluteId = "911";

    /// <summary>The horse flute to play when the summon key is pressed.</summary>
 //   private readonly Lazy<SObject> HorseFlute = new(() => ItemRegistry.Create<SObject>("(O)" + ModEntry.HorseFluteId));

    /// <summary>The mod configuration.</summary>
    private ModConfig Config = null!; // set in Entry

    /// <summary>The summon key binding.</summary>
    private KeybindList ToggleAutomaticEatingKey => this.Config.ToggleAutomaticEating;
    private KeybindList ToggleAutomaticDrinkingKey => this.Config.ToggleAutomaticDrinking;


    /*********
    ** Public methods
    *********/
    /// <inheritdoc />
    public override void Entry(IModHelper helper)
    {
        I18n.Init(helper.Translation);

        // load config
        this.UpdateConfig();

        // hook events
        helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        helper.Events.Input.ButtonsChanged += this.OnButtonsChanged;
        helper.Events.GameLoop.OneSecondUpdateTicked += this.OneSecondUpdateTicked;

        // hook commands

        // helper.ConsoleCommands.Add(command, description, function(string command, string[] args) {})
        /*
                helper.ConsoleCommands.Add("toggle_automatic_eating", "Toggle automatic eating",
                       (_, _) => this.ToggleAutomaticEating);
                helper.ConsoleCommands.Add("toggle_automatic_drinking", "Toggle automatic drinking",
                       (_, _) => this.ToggleAutomaticDrinking);
                helper.ConsoleCommands.Add("automatic_eating_slot", "Set automatic eating item slot",
                       (_, _) => this.SetEatingSlot);
                helper.ConsoleCommands.Add("automatic_drinking_slot", "Set automatic drinking item slot",
                       (_, _) => this.SetDrinkingSlot);
                helper.ConsoleCommands.Add("automatic_eating_item_name", "Set automatic eating item name",
                       (_, _) => this.SetEatingItemNAame);
                helper.ConsoleCommands.Add("automatic_drinking_item_name", "Set automatic drinking item name",
                       (_, _) => this.SetDrinkingItemName);
                helper.ConsoleCommands.Add("expire_food_buff", "expire food buff (immediately or in N seconds)",
                       (_, _) => this.ExpireFoodBuff);
                helper.ConsoleCommands.Add("expire_drink_buff", "expire food buff (immediately or in N seconds)",
                       (_, _) => this.ExpireDrinkBuff);
                helper.ConsoleCommands.Add("eat_auto_food", "eat auto food now",
                       (_, _) => this.EatAutoFood);
                    helper.ConsoleCommands.Add("eat_auto_food", "eat auto food now",
                       (_, _) => this.EatAutoDrink);     
                       */

    }


    /*********
    ** Private methods
    *********/

    private void OneSecondUpdateTicked(object? sender, OneSecondUpdateTickedEventArgs e)
    {
        string logPrefix = "AutomaticDining: OneSecondUpdateTicked: ";

        // 60 ticks to a second
        const int heartbeat_secs = 10;
        if (e.IsMultipleOf(60 * heartbeat_secs))
        {
            this.Monitor.Log($"AutomaticDining: " + heartbeat_secs + " seconds passed",
             LogLevel.Info /* TODO: lower level */);

            IDictionary<string, Buff> appliedBuffs = Game1.player.buffs.AppliedBuffs;
            this.Monitor.VerboseLog(logPrefix + appliedBuffs.ToString());

        }
        if (e.IsMultipleOf(60 * 10))
        {

        }
    }

    /// <inheritdoc cref="IGameLoopEvents.GameLaunched" />
    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
    {
        this.Monitor.VerboseLog($"AutomaticDining: is Loaded!");

        /*
        // add config UI
        this.AddGenericModConfigMenu(
            new GenericModConfigMenuIntegrationForAutomaticDining(),
            get: () => this.Config,
            set: config => this.Config = config,
            onSaved: this.UpdateConfig
        );
 */

    }

    /// <inheritdoc cref="IInputEvents.ButtonsChanged" />
    private void OnButtonsChanged(object? sender, ButtonsChangedEventArgs e)
    {

        // TODO
    }

    /// <summary>Update the mod configuration.</summary>
    private void UpdateConfig()
    {
        this.Config = this.Helper.ReadConfig<ModConfig>();
    }

}
