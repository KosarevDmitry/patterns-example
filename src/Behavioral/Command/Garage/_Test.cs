namespace Patterns.Behavioral.Command.Garage;

public class Test
{
    [Fact]
    public void Command_Garage()
    {
        var remoteControl = new RemoteControl(3);

        var bike          = new Garage("Bike");
        var bikeDoorClose = new GarageDoorCloseCommand(bike);
        var bikeDoorOpen  = new GarageDoorOpenCommand(bike);

        var car          = new Garage("Car");
        var carDoorClose = new GarageDoorCloseCommand(car);
        var carDoorOpen  = new GarageDoorOpenCommand(car);

        var garageButton = new OnOffStruct
        {
            On = bikeDoorOpen, Off = bikeDoorClose
        };

        remoteControl[0] = garageButton;
        remoteControl.PushOn(0);
        remoteControl.PushUndo();
        remoteControl.PushUndo();
        remoteControl.PushOff(0);

        
        var light = new Light("Hall");

        ICommand[] partyOn  = { new LightOffCommand(light), bikeDoorOpen, carDoorOpen };
        ICommand[] partyOff = { new LightOnCommand(light), bikeDoorClose, carDoorClose };

        remoteControl[2] = new OnOffStruct { On = new MacroCommand(partyOn), Off = new MacroCommand(partyOff) };

        try
        {
            remoteControl.PushOn(2);
        
            remoteControl.PushOff(2);
        }
        catch (Exception ex)
        {
        Assert.Fail(ex.Message);
        }
    }

}