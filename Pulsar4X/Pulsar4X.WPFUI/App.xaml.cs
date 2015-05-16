﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Pulsar4X.ECSLib;

namespace Pulsar4X.WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static Game GameInstance;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Register an event for all TextBoxes.
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
            base.OnStartup(e);
        }

        /// <summary>
        /// Event handler for TextBoxes getting focus from the keyboard tab.
        /// Causes the textbox to highlight its text when tabbed into.
        /// </summary>
        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        App()
        {
            /* Stuff to replace */
            Game game = new Game();
            Guid playerFaction = game.GlobalManager.GetFirstEntityWithDataBlob<FactionDB>().Guid;
            Entity factionEntity;
            if (!game.GlobalManager.TryGetEntityByGuid(playerFaction, out factionEntity))
            {
                factionEntity = FactionFactory.CreateFaction(game.GlobalManager, "playerFaction");
            }
            game.EngineComms.AddFaction(playerFaction);
            Guid faction = game.EngineComms.FirstOrDefault().Faction; //just get the first one for now, till we've got ui to select.
            /* Stuff to replace */

            UIComms uicomms = new UIComms(game.EngineComms, faction);
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => uicomms.CheckEngineMessageQueue()));
        }
    }
}