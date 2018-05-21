

namespace VD.Data.Base
{
    public interface IListService
    {
        void ChangeStatus(int id, int status);
        int ToggleStatus(int id);
        void UpdateOrder(int id, int order);
        void UpdateType(int id, string type);
        int GetOrderLast(int plus, string type);
    }
}
