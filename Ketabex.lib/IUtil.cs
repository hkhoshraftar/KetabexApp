using Ketabex.Shared;

namespace Ketabex
{
    public interface IUtil
    {
        void ShowMessage(string message);
        string GetDbPath();

        void SaveInLocal(string key, string value);
        string LoadFromLocal(string key);

        string GetDeviceUid();

        void SendBroadcast(MessageBusPayload paload);

        void ShowProgress();
        void DismissProgress();

    }
}
