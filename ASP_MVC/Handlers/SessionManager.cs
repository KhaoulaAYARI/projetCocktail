using ASP_MVC.Models.Cocktail;
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

        public IEnumerable<CocktailListItemMin> RecentlyVisetedCocktails
        {
            get {
                string? json = _session.GetString(nameof(RecentlyVisetedCocktails));
                if (json == null) return new List<CocktailListItemMin>();
                return JsonSerializer.Deserialize<CocktailListItemMin[]>(json);  
                }
            private set 
            {
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(RecentlyVisetedCocktails), json);
            }
        }

        public void Login(ConnectedUser user) 
        {
            ConnectedUser = user;
        }
        public void Logout()
        {
            ConnectedUser = null;
        }


        public void AddVisitedCocktail(CocktailListItemMin cocktail)
        {
           List<CocktailListItemMin> cocktails = new List<CocktailListItemMin>(RecentlyVisetedCocktails);
            CocktailListItemMin? cocktailInList=cocktails.Where(c=>c.Cocktail_id ==cocktail.Cocktail_id).SingleOrDefault();
            if (cocktailInList != null) 
            {
                cocktails.Remove(cocktailInList);
            }
            if(cocktails.Count == 5)
            {
                cocktails.Remove(cocktails[4]);
            }
            coc
        }
        public void AddVisitedCocktail(Guid cocktailId, string cocktail_name)
        {
            CocktailListItemMin cocktail = new CocktailListItemMin()
            {
                Cocktail_id = cocktailId,
                Name = cocktail_name
            };
            AddVisitedCocktail(cocktail);
        }
       
    }
}
