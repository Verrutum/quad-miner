using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    public partial class Program : MyGridProgram
    {
        private List<IMyPistonBase> retractablePistons = new List<IMyPistonBase>();
        private List<IMyPistonBase> horizontalPistons = new List<IMyPistonBase>();
        private List<IMyPistonBase> verticalPistons = new List<IMyPistonBase>();
        private EArguments parsedArgument;
        private EState currentState;

        private enum EState {
            INIT,
            WORK,
            PAUSE,
            COMPLETED,
        }

        private enum EArguments
        {
            INIT,
            START,
            PAUSE,
        }

        // Constants
        private const float stepDistance = 3.35f;
        private const int totalCycles = 3;


        public Program()
        {
            // The constructor, called only once every session and
            // always before any other method is called. Use it to
            // initialize your script. 
            currentState = EState.INIT;
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
        }

        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means.
        }

        public void Main(string argument, UpdateType updateSource)
        {
            // The main entry point of the script, invoked every time
            // one of the programmable block's Run actions are invoked,
            // or the script updates itself. The updateSource argument
            // describes where the update came from. Be aware that the
            // updateSource is a  bitfield  and might contain more than 
            // one update type.
            // 
            // The method itself is required, but the arguments above
            // can be removed if not needed.


            if (!string.IsNullOrEmpty(argument))
            {
                if (!Enum.TryParse<EArguments>(argument, true, out parsedArgument))
                {
                    Echo($"Unrecognised argument: \"{argument}\"");
                    return;
                }

                switch (parsedArgument)
                {
                    case EArguments.INIT:
                        currentState = EState.INIT;
                        break;
                    case EArguments.START:
                        currentState = EState.WORK;
                        break;
                    case EArguments.PAUSE:
                        currentState = EState.PAUSE;
                        break;
                }
            }

            if (!Enum.IsDefined(typeof(EState), currentState))
            {
                Echo($"Unrecognised state: \"{currentState}\"");
                return;
            }

            switch (currentState)
            {
                case EState.INIT:
                    //DoInit();
                    break;
                case EState.WORK:
                    //DoStart();
                    break;
                case EState.PAUSE:
                    //DoPause();
                    break;
                case EState.COMPLETED:
                    //DoCompleted();
                    break;

            }
        }
    }
}
