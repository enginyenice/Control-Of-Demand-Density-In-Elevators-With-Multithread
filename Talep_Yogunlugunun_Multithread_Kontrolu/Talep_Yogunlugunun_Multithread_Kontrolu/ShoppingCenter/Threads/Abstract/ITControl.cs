namespace ShoppingCenter.Threads.Abstract
{
    internal interface ITControl
    {
        bool ControlThread(Floor.Concrete.Floor[] floors, Elevator.Concrete.Elevator[] elevators, int capacity);
    }
}