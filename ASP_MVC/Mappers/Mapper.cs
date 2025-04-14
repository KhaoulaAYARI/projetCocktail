using ASP_MVC.Models.Cocktail;
using ASP_MVC.Models.User;
using BLL_Khaoula.Entities;

namespace ASP_MVC.Mappers
{
    internal static class Mapper
    {
        ///////////  User   ///////////

        public static UserListItem ToListItem(this User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new UserListItem()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
            };
        }
        public static UserDetails ToDetails(this User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new UserDetails()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email=user.Email,
                CreatedAt = DateOnly.FromDateTime(user.CreatedAt)
            };
        }

        public static User ToBLL(this UserCreateForm user) 
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password,
                DateTime.Now
                );
        }
        public static UserEditForm ToEditForm(this User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new UserEditForm()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }
        public static User ToBLL (this UserEditForm user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                "*********",
                DateTime.Now
                );
        }
        public static UserDelete ToDelete(this User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new UserDelete()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }
        ///////////  Cocktail   ///////////
        
        public static CocktailListItem ToListItem(this Cocktail cocktail)
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailListItem() 
            {
                Cocktail_id=cocktail.Cocktail_id,
                Name=cocktail.Name,
                Description=cocktail.Description
            };
        }
    }
}
