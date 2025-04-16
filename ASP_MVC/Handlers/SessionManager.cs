using System.Text.Json;

namespace ASP_MVC.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor accessor) 
        {
            _session = accessor.HttpContext.Session;
        }

        public ConnectedUser? ConnectedUser
        {
            get {return JsonSerializer.Deserialize<ConnectedUser?> (_session.GetString(nameof(ConnectedUser)) ?? "null"); }
            set {
                if (value == null)
                {
                    _session.Remove(nameof(ConnectedUser));
                }
                else 
                {
                    _session.SetString(nameof(ConnectedUser),JsonSerializer.Serialize(value));
                }
            
            }
        }

        public void Login(ConnectedUser user) 
        {
            ConnectedUser = user;
        }
       
    }
}
