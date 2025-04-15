using ASP_MVC.Models.Cocktail;
using ASP_MVC.Models.User;
using BLL_Khaoula.Entities;
using DAL_Khaoula.Entities;

namespace ASP_MVC.Mappers
{
    internal static class Mapper
    {
        ///////////  User   ///////////

        public static UserListItem ToListItem(this BLL_Khaoula.Entities.User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new UserListItem()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
            };
        }
        public static UserDetails ToDetails(this BLL_Khaoula.Entities.User user)
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

        public static BLL_Khaoula.Entities.User ToBLL(this UserCreateForm user) 
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new BLL_Khaoula.Entities.User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                user.Password,
                DateTime.Now
                );
        }
        public static UserEditForm ToEditForm(this BLL_Khaoula.Entities.User user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new UserEditForm()
            {
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email
            };
        }
        public static BLL_Khaoula.Entities.User ToBLL (this UserEditForm user)
        {
            if (user == null) { throw new ArgumentNullException(nameof(user)); }
            return new BLL_Khaoula.Entities.User(
                Guid.Empty,
                user.First_Name,
                user.Last_Name,
                user.Email,
                "*********",
                DateTime.Now
                );
        }
        public static UserDelete ToDelete(this BLL_Khaoula.Entities.User user)
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
        
        public static CocktailListItem ToListItem(this BLL_Khaoula.Entities.Cocktail cocktail)
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailListItem() 
            {
                Cocktail_id=cocktail.Cocktail_id,
                Name=cocktail.Name,
                Description=cocktail.Description
            };
        }

        public static CocktailDetails ToDetails (this BLL_Khaoula.Entities.Cocktail cocktail)
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailDetails() 
            {
                Cocktail_id = cocktail.Cocktail_id,
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions = cocktail.Instructions,
                CreatedAt=DateOnly.FromDateTime(cocktail.CreatedAt),
                CreatedBy=cocktail.CreatedBy
            };
        }

        public static BLL_Khaoula.Entities.Cocktail ToBLL(this CocktailCreateForm form)
        {
            if (form == null) throw new ArgumentNullException(nameof(form));
            return new BLL_Khaoula.Entities.Cocktail(
                Guid.Empty,
                form.Name,
                form.Description,
                form.Instructions,
                DateTime.Now,
                form.CreatedBy
                );
            
        }

        public static CocktailEditForm ToEditForm(this BLL_Khaoula.Entities.Cocktail cocktail)
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new CocktailEditForm()
            {
                Name = cocktail.Name,
                Description = cocktail.Description,
                Instructions= cocktail.Instructions
            };
        }

        public static BLL_Khaoula.Entities.Cocktail ToBLL(this CocktailEditForm cocktail)
        {
            if (cocktail == null) throw new ArgumentNullException(nameof(cocktail));
            return new BLL_Khaoula.Entities.Cocktail(
                Guid.Empty,
                cocktail.Name,
                cocktail.Description,
                cocktail.Instructions,
                DateTime.Now,
                Guid.Empty
                );

        }
    }
}
