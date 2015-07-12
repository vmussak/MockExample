using MockExample.Core.Notification;

namespace MockExample.Core.Client
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Notification.Notification Get(int id)
        {
            try
            {
                var client = _clientRepository.Get(id);
                if (client == null)
                    return Notification.Notification.Response(Status.NoContent);
                return Notification.Notification.Response(Status.Ok, client);
            }
            catch
            {
                return Notification.Notification.Response(Status.Error);
            }
        }
    }
}