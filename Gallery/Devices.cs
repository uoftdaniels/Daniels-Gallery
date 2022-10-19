using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// RAD
using Crestron.SimplSharp.Reflection;
using Crestron.RAD.Common;
using Crestron.RAD.Common.Interfaces;
using Crestron.RAD.Common.Enums;
using Crestron.RAD.ProTransports;
using Crestron.SimplSharp;

namespace Daniels.Gallery
{
    internal class Devices
    {

        private IBasicVideoDisplay _display;

        public virtual void Initialize(ControlSystem controlSystem)
        {
            string filename = "\\user\\Projector_Crestron_Crestron-Connected-Projector_CrestronConnected.dll";
            CrestronConsole.PrintLine("CCD: loading driver from `{0}`", filename);

            try
            {
                CType transportType = typeof(ICrestronConnected);

                var assembly = Assembly.LoadFrom(filename);
                CrestronConsole.PrintLine("CCD: assembly loaded: {0}", assembly.FullName);
                var type = assembly.GetTypes()
                            .FirstOrDefault(t => typeof(IBasicVideoDisplay).IsAssignableFrom(t) && transportType.IsAssignableFrom(t));
                CrestronConsole.PrintLine("CCD: found type: {0}", type.Name);
                _display = (IBasicVideoDisplay)Crestron.SimplSharp.Reflection.Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                //CrestronConsole.PrintLine("CCD: Create Instance failed {0}\r\n{1}", e.Message, e.StackTrace);
                CrestronConsole.ConsoleCommandResponse("CCD: Create Instance failed {0}\r\n{1}", e.Message, e.StackTrace);
                return;
            }

            CrestronConsole.PrintLine("CCD: driver `{0}` loaded", _display.BaseModel);
            // Initialize the transport

            ((ICrestronConnected)_display).Initialize(0x61, controlSystem);

            // Suscribe to events
            //_device.StateChangeEvent += new Action<DisplayStateObjects, IBasicVideoDisplay, byte>(DisplayStateChange);

            // Connect the driver to the device
            _display.Connect();
            CrestronConsole.ConsoleCommandResponse("CCD: driver `{0}` initialized", _display.BaseModel);

        }

    }
}
