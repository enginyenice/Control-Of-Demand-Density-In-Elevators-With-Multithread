using ShoppingCenter.Core;

namespace ShoppingCenter.Threads.Abstract
{
    public interface ITLogin
    {
        void LoginThread(Floor.Concrete.Floor[] floors, Settings settings);

        //Login Thread Function
    }
}